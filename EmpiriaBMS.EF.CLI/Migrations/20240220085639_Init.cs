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
                    table.ForeignKey(
                        name: "FK_Disciplines_Users_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Users",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments" },
                values: new object[,]
                {
                    { 151012370, "NBG_IBANK", 1, "D-22-167", 7, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7672), 12.0, -72, 38, "Test Description Project_42", "KL-7", new DateTime(2024, 5, 1, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7672), new DateTime(2024, 4, 24, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7672), 490, 61, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7672), 35, "Project_7", 5.0, new DateTime(2024, 5, 2, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7672), "Payment Detailes For Project_14", 7.0 },
                    { 242773335, "ALPHA", 1, "D-22-166", 8, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6780), 11.0, -69, 33, "Test Description Project_6", "KL-6", new DateTime(2024, 4, 28, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6780), new DateTime(2024, 4, 22, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6780), 360, 45, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6780), 30, "Project_6", 5.0, new DateTime(2024, 4, 29, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6780), "Payment Detailes For Project_12", 6.0 },
                    { 243287844, "NBG_IBANK", 1, "D-22-165", 10, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5895), 10.0, -66, 28, "Test Description Project_5", "KL-5", new DateTime(2024, 4, 25, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5895), new DateTime(2024, 4, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5895), 250, 31, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5895), 25, "Project_5", 5.0, new DateTime(2024, 4, 26, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5895), "Payment Detailes For Project_5", 5.0 },
                    { 314888324, "ALPHA", 4, "D-22-164", 12, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5013), 9.0, -63, 23, "Test Description Project_16", "KL-4", new DateTime(2024, 4, 22, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5013), new DateTime(2024, 4, 18, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5013), 160, 20, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5013), 20, "Project_4", 5.0, new DateTime(2024, 4, 23, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5013), "Payment Detailes For Project_12", 4.0 },
                    { 399609858, "ALPHA", 2, "D-22-162", 25, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3226), 7.0, -57, 13, "Test Description Project_8", "KL-2", new DateTime(2024, 4, 16, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3226), new DateTime(2024, 4, 14, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3226), 40, 5, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3226), 10, "Project_2", 5.0, new DateTime(2024, 4, 17, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3226), "Payment Detailes For Project_4", 2.0 },
                    { 462976299, "ALPHA", 1, "D-22-168", 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8555), 13.0, -75, 43, "Test Description Project_32", "KL-8", new DateTime(2024, 5, 4, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8555), new DateTime(2024, 4, 26, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8555), 640, 80, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8555), 40, "Project_8", 5.0, new DateTime(2024, 5, 5, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8555), "Payment Detailes For Project_32", 8.0 },
                    { 592688166, "NBG_IBANK", 1, "D-22-169", 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9452), 14.0, -78, 48, "Test Description Project_54", "KL-9", new DateTime(2024, 5, 7, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9452), new DateTime(2024, 4, 28, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9452), 810, 101, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9452), 45, "Project_9", 5.0, new DateTime(2024, 5, 8, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9452), "Payment Detailes For Project_36", 9.0 },
                    { 644186873, "NBG_IBANK", 3, "D-22-163", 17, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4125), 8.0, -60, 18, "Test Description Project_6", "KL-3", new DateTime(2024, 4, 19, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4125), new DateTime(2024, 4, 16, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4125), 90, 11, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4125), 15, "Project_3", 5.0, new DateTime(2024, 4, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4125), "Payment Detailes For Project_9", 3.0 },
                    { 799075877, "NBG_IBANK", 1, "D-22-161", 50, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2215), 6.0, -54, 8, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 13, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2215), new DateTime(2024, 4, 12, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2215), 10, 1, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2215), 5, "Project_1", 5.0, new DateTime(2024, 4, 14, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2215), "Payment Detailes For Project_5", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 144090492, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2061), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2062), "COO" },
                    { 163948015, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2054), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2055), "Project Manager" },
                    { 182745993, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2088), false, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2090), "Customer" },
                    { 265802291, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2082), false, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2083), "Guest" },
                    { 310331880, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2068), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2069), "CTO" },
                    { 666618742, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2075), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2076), "CEO" },
                    { 772544258, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2036), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2038), "Draftsmen" },
                    { 828438305, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2045), true, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2047), "Engineer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 126463126, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3592), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3593), null, "6949277784", null, null, null },
                    { 129420466, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8689), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8690), null, "69492777810", null, null, null },
                    { 129791966, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8029), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8030), null, "6949277789", null, null, null },
                    { 131879193, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8159), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8160), null, "6949277789", null, null, null },
                    { 132044152, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2808), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2809), null, "6949277783", null, null, null },
                    { 154347166, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7365), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7367), null, "6949277788", null, null, null },
                    { 157743701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8336), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8337), null, "6949277789", null, null, null },
                    { 157969960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8457), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8458), null, "6949277789", null, null, null },
                    { 161022507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4487), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4489), null, "6949277785", null, null, null },
                    { 162782057, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8739), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8740), null, "69492777810", null, null, null },
                    { 169484117, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7112), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7113), null, "6949277788", null, null, null },
                    { 171985458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3036), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3037), null, "6949277783", null, null, null },
                    { 177388719, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3948), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3949), null, "6949277784", null, null, null },
                    { 178285997, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8921), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8922), null, "69492777810", null, null, null },
                    { 179755879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3747), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3749), null, "6949277784", null, null, null },
                    { 180006284, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2404), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2406), null, "6949277783", null, null, null },
                    { 180016912, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8307), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8308), null, "6949277789", null, null, null },
                    { 193261537, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8482), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8483), null, "6949277789", null, null, null },
                    { 195693467, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6628), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6629), null, "6949277787", null, null, null },
                    { 200207510, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4907), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4908), null, "6949277785", null, null, null },
                    { 209615096, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5372), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5373), null, "6949277786", null, null, null },
                    { 213712192, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4759), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4760), null, "6949277785", null, null, null },
                    { 217333090, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9350), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9352), null, "69492777810", null, null, null },
                    { 218383339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4785), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4786), null, "6949277785", null, null, null },
                    { 219693837, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2987), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2988), null, "6949277783", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 221451728, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4259), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4260), null, "6949277785", null, null, null },
                    { 222961449, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5078), "Test Description PM 6", "alexpl_25@gmail.com", "Platanios_PM_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5079), null, "6949277786", null, null, null },
                    { 224883527, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6603), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6604), null, "6949277787", null, null, null },
                    { 225150809, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5674), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5675), null, "6949277786", null, null, null },
                    { 230606031, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9820), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9821), null, "69492777811", null, null, null },
                    { 232360197, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7339), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7340), null, "6949277788", null, null, null },
                    { 245219004, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8259), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8260), null, "6949277789", null, null, null },
                    { 248287879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5449), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5450), null, "6949277786", null, null, null },
                    { 249908182, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7775), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7776), null, "6949277789", null, null, null },
                    { 251310918, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9519), "Test Description PM 11", "alexpl_30@gmail.com", "Platanios_PM_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9520), null, "69492777811", null, null, null },
                    { 253689027, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7953), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7954), null, "6949277789", null, null, null },
                    { 254952851, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5424), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5425), null, "6949277786", null, null, null },
                    { 255931548, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2434), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2435), null, "6949277783", null, null, null },
                    { 260306259, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5498), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5499), null, "6949277786", null, null, null },
                    { 266774447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8185), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8186), null, "6949277789", null, null, null },
                    { 268273964, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4609), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4610), null, "6949277785", null, null, null },
                    { 274690524, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8846), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8847), null, "69492777810", null, null, null },
                    { 279108795, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4190), "Test Description PM 5", "alexpl_24@gmail.com", "Platanios_PM_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4191), null, "6949277785", null, null, null },
                    { 293070441, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9943), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9944), null, "69492777811", null, null, null },
                    { 296174611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5750), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5751), null, "6949277786", null, null, null },
                    { 303677148, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7594), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7595), null, "6949277788", null, null, null },
                    { 308972884, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3136), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3138), null, "6949277783", null, null, null },
                    { 310220316, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7215), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7216), null, "6949277788", null, null, null },
                    { 320836747, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8662), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8663), null, "69492777810", null, null, null },
                    { 322833279, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5799), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5800), null, "6949277786", null, null, null },
                    { 323780764, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9894), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9895), null, "69492777811", null, null, null },
                    { 331959960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5270), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5271), null, "6949277786", null, null, null },
                    { 336323975, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7849), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7851), null, "6949277789", null, null, null },
                    { 337333684, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7491), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7492), null, "6949277788", null, null, null },
                    { 340905184, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5347), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5348), null, "6949277786", null, null, null },
                    { 358782473, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4707), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4708), null, "6949277785", null, null, null },
                    { 366891928, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7290), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7291), null, "6949277788", null, null, null },
                    { 368431507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8622), "Test Description PM 10", "alexpl_29@gmail.com", "Platanios_PM_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8623), null, "69492777810", null, null, null },
                    { 378822134, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6257), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6258), null, "6949277787", null, null, null },
                    { 380536397, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2882), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2883), null, "6949277783", null, null, null },
                    { 393894281, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3640), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3641), null, "6949277784", null, null, null },
                    { 397479771, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3566), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3568), null, "6949277784", null, null, null },
                    { 397633729, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6677), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6678), null, "6949277787", null, null, null },
                    { 401554962, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8409), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8410), null, "6949277789", null, null, null },
                    { 402120139, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6082), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6083), null, "6949277787", null, null, null },
                    { 409548673, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5195), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5197), null, "6949277786", null, null, null },
                    { 410585751, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8970), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8971), null, "69492777810", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 415010409, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9121), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9122), null, "69492777810", null, null, null },
                    { 420389677, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3111), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3112), null, "6949277783", null, null, null },
                    { 426157165, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3973), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3974), null, "6949277784", null, null, null },
                    { 426208140, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3896), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3898), null, "6949277784", null, null, null },
                    { 434373207, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5296), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5297), null, "6949277786", null, null, null },
                    { 435205704, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6845), "Test Description PM 8", "alexpl_27@gmail.com", "Platanios_PM_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6846), null, "6949277788", null, null, null },
                    { 435690962, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(45), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(46), null, "69492777811", null, null, null },
                    { 440549913, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2960), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2961), null, "6949277783", null, null, null },
                    { 441447599, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7928), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7929), null, "6949277789", null, null, null },
                    { 443752132, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3871), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3872), null, "6949277784", null, null, null },
                    { 453650230, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4834), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4835), null, "6949277785", null, null, null },
                    { 455470879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2572), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2573), null, "6949277783", null, null, null },
                    { 462805017, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5646), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5647), null, "6949277786", null, null, null },
                    { 469081584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9564), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9565), null, "69492777811", null, null, null },
                    { 485408558, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6885), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6886), null, "6949277788", null, null, null },
                    { 487893729, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(194), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(195), null, "69492777811", null, null, null },
                    { 488233931, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4233), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4234), null, "6949277785", null, null, null },
                    { 490433615, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2908), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2909), null, "6949277783", null, null, null },
                    { 492951793, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4309), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4310), null, "6949277785", null, null, null },
                    { 494593460, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9665), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9667), null, "69492777811", null, null, null },
                    { 502914296, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6231), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6232), null, "6949277787", null, null, null },
                    { 504038786, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6330), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6331), null, "6949277787", null, null, null },
                    { 508473295, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9223), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9224), null, "69492777810", null, null, null },
                    { 513189499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7878), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7879), null, "6949277789", null, null, null },
                    { 519506777, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9715), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9716), null, "69492777811", null, null, null },
                    { 523556624, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6033), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6034), null, "6949277787", null, null, null },
                    { 530904331, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6305), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6306), null, "6949277787", null, null, null },
                    { 535561992, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3821), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3822), null, "6949277784", null, null, null },
                    { 539310697, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(94), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(95), null, "69492777811", null, null, null },
                    { 539469406, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3362), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3363), null, "6949277784", null, null, null },
                    { 542874168, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(20), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(21), null, "69492777811", null, null, null },
                    { 549836076, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6007), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6008), null, "6949277787", null, null, null },
                    { 553094711, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6964), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6965), null, "6949277788", null, null, null },
                    { 554933916, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7736), "Test Description PM 9", "alexpl_28@gmail.com", "Platanios_PM_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7737), null, "6949277789", null, null, null },
                    { 556937078, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9148), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9149), null, "69492777810", null, null, null },
                    { 557820952, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6705), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6706), null, "6949277787", null, null, null },
                    { 559391790, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2675), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2677), null, "6949277783", null, null, null },
                    { 566357499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6455), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6456), null, "6949277787", null, null, null },
                    { 570696662, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2495), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2496), null, "6949277783", null, null, null },
                    { 571175333, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5143), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5144), null, "6949277786", null, null, null },
                    { 573962458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6555), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6556), null, "6949277787", null, null, null },
                    { 581377268, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5221), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5222), null, "6949277786", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 584690616, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4682), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4683), null, "6949277785", null, null, null },
                    { 585891888, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2757), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2758), null, "6949277783", null, null, null },
                    { 591429218, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5523), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5524), null, "6949277786", null, null, null },
                    { 600193144, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(168), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(170), null, "69492777811", null, null, null },
                    { 605504845, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(119), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(121), null, "69492777811", null, null, null },
                    { 609573366, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6481), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6482), null, "6949277787", null, null, null },
                    { 611109689, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6529), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6531), null, "6949277787", null, null, null },
                    { 613755691, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8002), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8003), null, "6949277789", null, null, null },
                    { 627021105, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4939), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4941), null, "6949277785", null, null, null },
                    { 636676311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7441), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7442), null, "6949277788", null, null, null },
                    { 644115642, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4047), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4048), null, "6949277784", null, null, null },
                    { 656753350, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2730), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2731), null, "6949277783", null, null, null },
                    { 657681151, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6989), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6990), null, "6949277788", null, null, null },
                    { 664001206, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7063), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7064), null, "6949277788", null, null, null },
                    { 668214878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7801), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7802), null, "6949277789", null, null, null },
                    { 675589020, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3413), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3414), null, "6949277784", null, null, null },
                    { 685171448, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3062), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3063), null, "6949277783", null, null, null },
                    { 689472878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9869), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9870), null, "69492777811", null, null, null },
                    { 693432582, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7038), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7039), null, "6949277788", null, null, null },
                    { 701684122, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(270), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(271), null, "69492777811", null, null, null },
                    { 705530604, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9272), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9273), null, "69492777810", null, null, null },
                    { 705821701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8384), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8385), null, "6949277789", null, null, null },
                    { 713951802, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5724), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5725), null, "6949277786", null, null, null },
                    { 721247179, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4634), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4635), null, "6949277785", null, null, null },
                    { 723493136, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9591), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9592), null, "69492777811", null, null, null },
                    { 730339311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9197), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9198), null, "69492777810", null, null, null },
                    { 731224359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8104), "Test Description Draftsman 9", "alexpl_9@gmail.com", "Platanios_Draftsman_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8106), null, "6949277789", null, null, null },
                    { 740615414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9301), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9302), null, "69492777810", null, null, null },
                    { 746098787, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7520), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7521), null, "6949277788", null, null, null },
                    { 746635828, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6911), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6912), null, "6949277788", null, null, null },
                    { 747860447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7138), "Test Description Draftsman 8", "alexpl_8@gmail.com", "Platanios_Draftsman_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7139), null, "6949277788", null, null, null },
                    { 752076073, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4409), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4410), null, "6949277785", null, null, null },
                    { 754853037, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6155), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6156), null, "6949277787", null, null, null },
                    { 761174709, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5116), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5118), null, "6949277786", null, null, null },
                    { 765880408, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2647), "Test Description Engineer 3", "alexpl_3@gmail.com", "Platanios_Engineer_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2649), null, "6949277783", null, null, null },
                    { 766521353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5572), "Test Description Engineer 6", "alexpl_6@gmail.com", "Platanios_Engineer_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5573), null, "6949277786", null, null, null },
                    { 769949996, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9044), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9045), null, "69492777810", null, null, null },
                    { 772957960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4562), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4563), null, "6949277785", null, null, null },
                    { 779484745, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6403), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6404), null, "6949277787", null, null, null },
                    { 783342377, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9072), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9073), null, "69492777810", null, null, null },
                    { 797931672, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4021), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4022), null, "6949277784", null, null, null },
                    { 802618491, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5967), "Test Description PM 7", "alexpl_26@gmail.com", "Platanios_PM_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5968), null, "6949277787", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 807257708, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3796), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3797), null, "6949277784", null, null, null },
                    { 809086236, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4536), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4537), null, "6949277785", null, null, null },
                    { 827785916, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8995), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8996), null, "69492777810", null, null, null },
                    { 831848783, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6183), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6184), null, "6949277787", null, null, null },
                    { 834678410, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7569), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7570), null, "6949277788", null, null, null },
                    { 846681520, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2355), "Test Description PM 3", "alexpl_22@gmail.com", "Platanios_PM_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2357), null, "6949277783", null, null, null },
                    { 849016006, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9376), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9377), null, "69492777810", null, null, null },
                    { 853036468, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4859), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4860), null, "6949277785", null, null, null },
                    { 855753052, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3295), "Test Description PM 4", "alexpl_23@gmail.com", "Platanios_PM_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3296), null, "6949277784", null, null, null },
                    { 856738611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3439), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3440), null, "6949277784", null, null, null },
                    { 862349087, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5597), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5598), null, "6949277786", null, null, null },
                    { 866042339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4335), "Test Description Draftsman 5", "alexpl_5@gmail.com", "Platanios_Draftsman_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4336), null, "6949277785", null, null, null },
                    { 882236221, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5824), "Test Description Draftsman 6", "alexpl_6@gmail.com", "Platanios_Draftsman_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5825), null, "6949277786", null, null, null },
                    { 892732481, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9740), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9742), null, "69492777811", null, null, null },
                    { 895193332, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2597), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2598), null, "6949277783", null, null, null },
                    { 896693369, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2523), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2524), null, "6949277783", null, null, null },
                    { 909809411, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4458), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4459), null, "6949277785", null, null, null },
                    { 913558359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7415), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7416), null, "6949277788", null, null, null },
                    { 916807235, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3491), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3492), null, "6949277784", null, null, null },
                    { 918998516, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9640), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9641), null, "69492777811", null, null, null },
                    { 919500855, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7186), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7187), null, "6949277788", null, null, null },
                    { 921296394, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(244), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(245), null, "69492777811", null, null, null },
                    { 926204579, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3722), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3723), null, "6949277784", null, null, null },
                    { 938150687, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6378), "Test Description Engineer 7", "alexpl_7@gmail.com", "Platanios_Engineer_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6379), null, "6949277787", null, null, null },
                    { 938673504, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8079), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8080), null, "6949277789", null, null, null },
                    { 938835114, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8233), "Test Description Engineer 9", "alexpl_9@gmail.com", "Platanios_Engineer_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8235), null, "6949277789", null, null, null },
                    { 943880584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3669), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3670), null, "6949277784", null, null, null },
                    { 947132395, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8894), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8896), null, "69492777810", null, null, null },
                    { 952621353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4384), "Test Description Engineer 5", "alexpl_5@gmail.com", "Platanios_Engineer_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4385), null, "6949277785", null, null, null },
                    { 957077905, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2833), "Test Description Draftsman 3", "alexpl_3@gmail.com", "Platanios_Draftsman_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2835), null, "6949277783", null, null, null },
                    { 962334030, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9793), "Test Description Engineer 11", "alexpl_11@gmail.com", "Platanios_Engineer_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9795), null, "69492777811", null, null, null },
                    { 974014414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7264), "Test Description Engineer 8", "alexpl_8@gmail.com", "Platanios_Engineer_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7265), null, "6949277788", null, null, null },
                    { 980229955, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6107), "Test Description Draftsman 7", "alexpl_7@gmail.com", "Platanios_Draftsman_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6108), null, "6949277787", null, null, null },
                    { 990812334, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8814), "Test Description Engineer 10", "alexpl_10@gmail.com", "Platanios_Engineer_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8815), null, "69492777810", null, null, null },
                    { 992271205, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3335), "Test Description Engineer 4", "alexpl_4@gmail.com", "Platanios_Engineer_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3337), null, "6949277784", null, null, null },
                    { 992706426, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9969), "Test Description Draftsman 11", "alexpl_11@gmail.com", "Platanios_Draftsman_11", 72.0, "Alexandros_11", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9970), null, "69492777811", null, null, null },
                    { 994713011, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8765), "Test Description Draftsman 10", "alexpl_10@gmail.com", "Platanios_Draftsman_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8766), null, "69492777810", null, null, null },
                    { 997452540, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3517), "Test Description Draftsman 4", "alexpl_4@gmail.com", "Platanios_Draftsman_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3519), null, "6949277784", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 265901953, 7, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7762), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7763), "ELEC", 151012370, 554933916 },
                    { 336108878, 17, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4220), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4221), "ELEC", 644186873, 279108795 },
                    { 474679962, 25, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3322), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3323), "HVAC", 399609858, 855753052 },
                    { 489504759, 50, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2388), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2389), "ELEC", 799075877, 846681520 },
                    { 615430181, 8, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6872), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6873), "HVAC", 242773335, 435205704 },
                    { 673804234, 12, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5104), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5106), "HVAC", 314888324, 222961449 },
                    { 701538149, 10, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5993), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5994), "ELEC", 243287844, 802618491 },
                    { 794985958, 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8650), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8651), "HVAC", 462976299, 368431507 },
                    { 797842216, 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9550), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9551), "ELEC", 592688166, 251310918 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 265421323, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2333), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2335), 3010.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2334), "Signature 142344", 11272, 799075877, 1.0, 17.0 },
                    { 302847800, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6830), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6832), 1003000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6831), "Signature 1423430", 33214, 242773335, 6.0, 24.0 },
                    { 359742797, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4174), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4176), 4000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4175), "Signature 1423415", 83435, 644186873, 3.0, 17.0 },
                    { 515148348, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7721), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7723), 10003000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7722), "Signature 142347", 16298, 151012370, 7.0, 17.0 },
                    { 575626210, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5949), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5952), 103000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5951), "Signature 1423425", 10019, 243287844, 5.0, 17.0 },
                    { 589979851, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8606), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8609), 100003000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8608), "Signature 142348", 18117, 462976299, 8.0, 24.0 },
                    { 607910345, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9502), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9505), 1000003000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9503), "Signature 1423436", 57738, 592688166, 9.0, 17.0 },
                    { 690454726, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3278), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3280), 3100.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3279), "Signature 142342", 41033, 399609858, 2.0, 24.0 },
                    { 992603148, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5062), new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5064), 13000.0, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5063), "Signature 1423424", 56791, 314888324, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 772544258, 126463126, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3606), 539533114, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3607) },
                    { 772544258, 129420466, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8704), 957266007, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8705) },
                    { 772544258, 129791966, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8043), 550036476, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8044) },
                    { 828438305, 131879193, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8173), 476654918, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8174) },
                    { 828438305, 132044152, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2822), 304481240, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2823) },
                    { 772544258, 154347166, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7380), 435295770, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7381) },
                    { 772544258, 157743701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8350), 526878049, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8351) },
                    { 828438305, 157969960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8471), 385196500, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8472) },
                    { 772544258, 161022507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4501), 812918228, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4503) },
                    { 828438305, 162782057, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8753), 927710759, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8754) },
                    { 828438305, 169484117, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7126), 126853494, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7127) },
                    { 828438305, 171985458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3050), 557001692, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3051) },
                    { 828438305, 177388719, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3962), 601469906, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3963) },
                    { 772544258, 178285997, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8935), 561834964, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8936) },
                    { 772544258, 179755879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3762), 440365650, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3763) },
                    { 828438305, 180006284, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2421), 208978663, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2422) },
                    { 828438305, 180016912, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8324), 487624721, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8325) },
                    { 772544258, 193261537, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8496), 660195157, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8497) },
                    { 772544258, 195693467, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6642), 694859486, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6643) },
                    { 828438305, 200207510, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4923), 815114571, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4924) },
                    { 772544258, 209615096, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5386), 781313266, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5387) },
                    { 828438305, 213712192, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4773), 248620261, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4775) },
                    { 828438305, 217333090, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9365), 726871942, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9366) },
                    { 772544258, 218383339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4799), 960158927, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4800) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 772544258, 219693837, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3002), 142959142, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3003) },
                    { 772544258, 221451728, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4275), 727350345, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4276) },
                    { 163948015, 222961449, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5092), 184836624, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5093) },
                    { 828438305, 224883527, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6616), 616545464, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6617) },
                    { 772544258, 225150809, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5689), 580403200, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5690) },
                    { 772544258, 230606031, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9834), 161141403, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9835) },
                    { 828438305, 232360197, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7354), 799747430, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7355) },
                    { 772544258, 245219004, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8273), 836385085, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8274) },
                    { 772544258, 248287879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5463), 499162933, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5465) },
                    { 828438305, 249908182, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7789), 443602658, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7790) },
                    { 163948015, 251310918, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9538), 670092087, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9539) },
                    { 772544258, 253689027, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7968), 346312968, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7969) },
                    { 828438305, 254952851, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5438), 183884418, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5439) },
                    { 772544258, 255931548, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2455), 816860005, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2457) },
                    { 828438305, 260306259, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5511), 251975521, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5513) },
                    { 772544258, 266774447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8199), 847456067, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8200) },
                    { 828438305, 268273964, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4622), 799318754, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4624) },
                    { 772544258, 274690524, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8860), 845205345, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8861) },
                    { 163948015, 279108795, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4208), 154158616, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4209) },
                    { 828438305, 293070441, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9957), 724601667, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9958) },
                    { 772544258, 296174611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5764), 487104413, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5765) },
                    { 772544258, 303677148, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7612), 934280110, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7613) },
                    { 772544258, 308972884, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3151), 221211814, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3152) },
                    { 772544258, 310220316, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7230), 337955736, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7231) },
                    { 828438305, 320836747, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8677), 194501310, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8678) },
                    { 828438305, 322833279, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5813), 151763951, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5814) },
                    { 772544258, 323780764, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9908), 543747056, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9910) },
                    { 828438305, 331959960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5284), 745448597, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5285) },
                    { 828438305, 336323975, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7866), 623014862, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7867) },
                    { 828438305, 337333684, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7507), 798380883, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7508) },
                    { 828438305, 340905184, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5361), 457736193, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5362) },
                    { 772544258, 358782473, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4725), 433400584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4726) },
                    { 772544258, 366891928, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7304), 491305710, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7306) },
                    { 163948015, 368431507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8638), 316482623, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8640) },
                    { 772544258, 378822134, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6271), 655769822, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6272) },
                    { 828438305, 380536397, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2896), 403671473, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2897) },
                    { 828438305, 393894281, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3656), 683091248, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3658) },
                    { 828438305, 397479771, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3580), 187963632, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3581) },
                    { 828438305, 397633729, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6693), 310962351, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6694) },
                    { 772544258, 401554962, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8423), 794948383, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8424) },
                    { 828438305, 402120139, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6096), 965686213, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6097) },
                    { 828438305, 409548673, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5210), 204087914, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5211) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 828438305, 410585751, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8984), 413756194, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8985) },
                    { 828438305, 415010409, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9136), 357312366, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9137) },
                    { 828438305, 420389677, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3125), 249741813, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3126) },
                    { 772544258, 426157165, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3987), 405437064, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3988) },
                    { 772544258, 426208140, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3911), 371418300, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3912) },
                    { 772544258, 434373207, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5310), 849306113, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5311) },
                    { 163948015, 435205704, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6860), 927543797, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6861) },
                    { 772544258, 435690962, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(59), 408209979, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(61) },
                    { 828438305, 440549913, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2975), 683983135, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2976) },
                    { 828438305, 441447599, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7942), 613444824, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7943) },
                    { 828438305, 443752132, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3885), 216291677, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3886) },
                    { 828438305, 453650230, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4848), 470996070, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4849) },
                    { 828438305, 455470879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2586), 757327043, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2587) },
                    { 828438305, 462805017, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5660), 851304836, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5661) },
                    { 828438305, 469081584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9579), 925653836, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9580) },
                    { 828438305, 485408558, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6899), 520527676, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6900) },
                    { 772544258, 487893729, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(208), 369442974, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(209) },
                    { 828438305, 488233931, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4247), 156288030, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4248) },
                    { 772544258, 490433615, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2922), 302730996, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2923) },
                    { 828438305, 492951793, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4324), 962037169, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4325) },
                    { 772544258, 494593460, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9680), 418599098, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9681) },
                    { 828438305, 502914296, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6245), 327410054, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6246) },
                    { 772544258, 504038786, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6344), 442290188, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6345) },
                    { 772544258, 508473295, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9238), 592065285, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9239) },
                    { 772544258, 513189499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7893), 879297675, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7894) },
                    { 828438305, 519506777, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9729), 762277101, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9730) },
                    { 772544258, 523556624, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6048), 624182271, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6049) },
                    { 828438305, 530904331, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6319), 845229845, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6320) },
                    { 772544258, 535561992, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3835), 690829984, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3836) },
                    { 828438305, 539310697, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(108), 273095985, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(109) },
                    { 772544258, 539469406, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3378), 917892762, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3379) },
                    { 828438305, 542874168, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(34), 636859167, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(35) },
                    { 828438305, 549836076, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6022), 258661060, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6023) },
                    { 828438305, 553094711, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6978), 162662106, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6979) },
                    { 163948015, 554933916, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7750), 777272515, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7751) },
                    { 772544258, 556937078, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9163), 466536461, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9164) },
                    { 772544258, 557820952, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6719), 762692375, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6720) },
                    { 772544258, 559391790, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2694), 361744727, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2695) },
                    { 828438305, 566357499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6469), 277213166, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6471) },
                    { 828438305, 570696662, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2510), 148539459, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2511) },
                    { 772544258, 571175333, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5157), 793301896, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5158) },
                    { 772544258, 573962458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6569), 454653989, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6570) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 772544258, 581377268, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5235), 812591230, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5236) },
                    { 828438305, 584690616, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4695), 199832316, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4697) },
                    { 772544258, 585891888, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2772), 364149560, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2774) },
                    { 772544258, 591429218, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5537), 457954714, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5539) },
                    { 828438305, 600193144, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(182), 728504487, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(184) },
                    { 772544258, 605504845, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(134), 729344163, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(135) },
                    { 772544258, 609573366, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6495), 975761950, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6496) },
                    { 828438305, 611109689, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6543), 845350450, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6544) },
                    { 828438305, 613755691, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8017), 227233899, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8018) },
                    { 772544258, 627021105, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4954), 659091460, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4955) },
                    { 772544258, 636676311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7455), 571060664, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7456) },
                    { 772544258, 644115642, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4061), 810087448, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4062) },
                    { 828438305, 656753350, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2745), 881572429, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2746) },
                    { 772544258, 657681151, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7003), 754889897, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7005) },
                    { 772544258, 664001206, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7078), 854703524, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7079) },
                    { 772544258, 668214878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7815), 741032025, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7816) },
                    { 828438305, 675589020, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3427), 763136339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3428) },
                    { 772544258, 685171448, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3076), 219748145, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3077) },
                    { 828438305, 689472878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9883), 782215922, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9884) },
                    { 828438305, 693432582, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7052), 291759597, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7053) },
                    { 772544258, 701684122, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(284), 983615063, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(286) },
                    { 828438305, 705530604, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9289), 445911207, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9291) },
                    { 828438305, 705821701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8397), 637030258, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8399) },
                    { 828438305, 713951802, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5738), 420494815, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5739) },
                    { 772544258, 721247179, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4648), 753520782, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4649) },
                    { 772544258, 723493136, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9605), 204836826, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9606) },
                    { 828438305, 730339311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9211), 569884619, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9212) },
                    { 772544258, 731224359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8122), 978781119, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8123) },
                    { 772544258, 740615414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9316), 635053061, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9317) },
                    { 772544258, 746098787, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7535), 847603360, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7536) },
                    { 772544258, 746635828, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6926), 663386751, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6927) },
                    { 772544258, 747860447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7152), 819096723, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7153) },
                    { 772544258, 752076073, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4423), 573209537, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4425) },
                    { 828438305, 754853037, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6168), 154748180, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6169) },
                    { 828438305, 761174709, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5132), 967816260, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5133) },
                    { 828438305, 765880408, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2663), 814197665, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2664) },
                    { 828438305, 766521353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5586), 412454714, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5587) },
                    { 828438305, 769949996, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9060), 953938588, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9062) },
                    { 772544258, 772957960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4575), 780842611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4576) },
                    { 772544258, 779484745, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6418), 387062008, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6419) },
                    { 772544258, 783342377, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9087), 210129545, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9088) },
                    { 828438305, 797931672, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4035), 694692825, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4036) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 163948015, 802618491, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5981), 159736332, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5983) },
                    { 828438305, 807257708, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3810), 875758404, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3811) },
                    { 828438305, 809086236, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4550), 362527515, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4551) },
                    { 772544258, 827785916, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9009), 262868483, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9010) },
                    { 772544258, 831848783, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6198), 425867590, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6199) },
                    { 828438305, 834678410, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7582), 653698771, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7583) },
                    { 163948015, 846681520, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2374), 276733919, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2375) },
                    { 772544258, 849016006, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9391), 588933460, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9392) },
                    { 772544258, 853036468, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4873), 677532096, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4874) },
                    { 163948015, 855753052, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3310), 989937839, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3311) },
                    { 772544258, 856738611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3453), 220201580, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3454) },
                    { 772544258, 862349087, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5612), 151859701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5613) },
                    { 772544258, 866042339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4350), 906045452, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4351) },
                    { 772544258, 882236221, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5838), 308875869, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5839) },
                    { 772544258, 892732481, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9755), 145247345, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9756) },
                    { 772544258, 895193332, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2612), 407238186, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2613) },
                    { 772544258, 896693369, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2538), 478150086, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2539) },
                    { 828438305, 909809411, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4476), 889675283, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4477) },
                    { 828438305, 913558359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7429), 815275567, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7430) },
                    { 828438305, 916807235, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3506), 719889324, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3507) },
                    { 828438305, 918998516, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9654), 869701602, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9655) },
                    { 828438305, 919500855, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7200), 439741859, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7201) },
                    { 828438305, 921296394, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(258), 418246253, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(260) },
                    { 828438305, 926204579, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3736), 862201291, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3737) },
                    { 828438305, 938150687, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6392), 878990425, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6393) },
                    { 828438305, 938673504, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8093), 205687454, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8094) },
                    { 828438305, 938835114, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8247), 311833865, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8248) },
                    { 772544258, 943880584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3684), 734746559, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3685) },
                    { 828438305, 947132395, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8909), 355871254, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8910) },
                    { 828438305, 952621353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4398), 649366372, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4399) },
                    { 772544258, 957077905, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2848), 913289074, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2849) },
                    { 828438305, 962334030, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9808), 863575357, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9809) },
                    { 828438305, 974014414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7278), 563687394, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7279) },
                    { 772544258, 980229955, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6121), 224182440, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6122) },
                    { 828438305, 990812334, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8834), 492405281, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8835) },
                    { 828438305, 992271205, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3350), 127960618, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3351) },
                    { 772544258, 992706426, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9982), 224081800, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9984) },
                    { 772544258, 994713011, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8779), 399254452, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8780) },
                    { 772544258, 997452540, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3532), 579364993, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3533) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 207727998, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6803), "Test Description Customer 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6804), null, "6949277786", null, null, 242773335 },
                    { 223019398, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9474), "Test Description Customer 9", "alexpl_9@gmail.com", "Platanios_Customer_9", null, "Alexandros_9", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9475), null, "6949277789", null, null, 592688166 },
                    { 252830069, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7694), "Test Description Customer 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7695), null, "6949277787", null, null, 151012370 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 337388796, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5035), "Test Description Customer 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5037), null, "6949277784", null, null, 314888324 },
                    { 470401103, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8580), "Test Description Customer 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8581), null, "6949277788", null, null, 462976299 },
                    { 778268350, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2267), "Test Description Customer 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2268), null, "6949277781", null, null, 799075877 },
                    { 810063655, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4147), "Test Description Customer 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4149), null, "6949277783", null, null, 644186873 },
                    { 833534571, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3249), "Test Description Customer 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3250), null, "6949277782", null, null, 399609858 },
                    { 967556265, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5918), "Test Description Customer 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5919), null, "6949277785", null, null, 243287844 }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 265901953, 129791966, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8068), 807805455, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8069) },
                    { 265901953, 131879193, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8211), 397476709, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8212) },
                    { 265901953, 157743701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8373), 284413788, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8374) },
                    { 265901953, 157969960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8508), 957413564, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8509) },
                    { 265901953, 180016912, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8361), 678868701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8362) },
                    { 265901953, 193261537, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8520), 627733346, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8521) },
                    { 265901953, 245219004, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8296), 718496516, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8297) },
                    { 265901953, 249908182, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7827), 390922273, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7828) },
                    { 265901953, 253689027, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7991), 215140560, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7992) },
                    { 265901953, 266774447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8222), 874927432, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8223) },
                    { 265901953, 336323975, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7905), 313769485, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7906) },
                    { 265901953, 401554962, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8446), 321731285, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8447) },
                    { 265901953, 441447599, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7979), 551664653, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7981) },
                    { 265901953, 513189499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7916), 604192614, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7917) },
                    { 265901953, 613755691, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8056), 939918919, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8057) },
                    { 265901953, 668214878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7838), 650176066, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7839) },
                    { 265901953, 705821701, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8435), 566949591, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8436) },
                    { 265901953, 731224359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8148), 639945924, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8149) },
                    { 265901953, 938673504, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8134), 652331104, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8135) },
                    { 265901953, 938835114, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8284), 461090576, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8285) },
                    { 336108878, 161022507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4524), 835023979, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4525) },
                    { 336108878, 200207510, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4966), 350540050, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4967) },
                    { 336108878, 213712192, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4811), 210151175, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4812) },
                    { 336108878, 218383339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4822), 174637191, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4824) },
                    { 336108878, 221451728, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4298), 625950045, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4299) },
                    { 336108878, 268273964, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4659), 660935969, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4660) },
                    { 336108878, 358782473, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4748), 336178772, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4749) },
                    { 336108878, 453650230, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4885), 883047696, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4886) },
                    { 336108878, 488233931, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4286), 139207186, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4288) },
                    { 336108878, 492951793, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4361), 183542271, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4362) },
                    { 336108878, 584690616, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4736), 294879341, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4738) },
                    { 336108878, 627021105, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4977), 301249324, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4979) },
                    { 336108878, 721247179, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4670), 784610674, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4671) },
                    { 336108878, 752076073, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4447), 946052469, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4448) },
                    { 336108878, 772957960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4598), 890283392, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4599) },
                    { 336108878, 809086236, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4587), 915971267, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4588) },
                    { 336108878, 853036468, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4896), 411908829, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4897) },
                    { 336108878, 866042339, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4372), 743700992, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4373) },
                    { 336108878, 909809411, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4513), 652656329, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4514) },
                    { 336108878, 952621353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4435), 580478914, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4436) },
                    { 474679962, 126463126, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3629), 485420851, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3630) },
                    { 474679962, 177388719, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3998), 406111838, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3999) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 474679962, 179755879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3784), 202145168, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3786) },
                    { 474679962, 393894281, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3699), 327499982, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3700) },
                    { 474679962, 397479771, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3617), 244596821, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3619) },
                    { 474679962, 426157165, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4010), 162490051, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4011) },
                    { 474679962, 426208140, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3933), 799280917, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3934) },
                    { 474679962, 443752132, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3922), 266467580, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3923) },
                    { 474679962, 535561992, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3860), 473700894, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3861) },
                    { 474679962, 539469406, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3401), 163857296, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3402) },
                    { 474679962, 644115642, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4084), 587145670, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4085) },
                    { 474679962, 675589020, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3468), 467164512, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3469) },
                    { 474679962, 797931672, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4072), 484064223, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4073) },
                    { 474679962, 807257708, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3846), 883121262, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3847) },
                    { 474679962, 856738611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3480), 178341259, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3481) },
                    { 474679962, 916807235, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3544), 941040878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3545) },
                    { 474679962, 926204579, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3773), 319438884, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3774) },
                    { 474679962, 943880584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3710), 179458681, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3711) },
                    { 474679962, 992271205, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3389), 432569176, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3390) },
                    { 474679962, 997452540, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3555), 546497358, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3556) },
                    { 489504759, 132044152, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2859), 313075598, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2860) },
                    { 489504759, 171985458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3088), 163979943, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3089) },
                    { 489504759, 180006284, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2468), 866741807, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2469) },
                    { 489504759, 219693837, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3025), 978149397, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3026) },
                    { 489504759, 255931548, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2482), 627746026, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2484) },
                    { 489504759, 308972884, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3173), 874301676, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3174) },
                    { 489504759, 380536397, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2934), 179571501, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2935) },
                    { 489504759, 420389677, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3162), 675424282, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3163) },
                    { 489504759, 440549913, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3014), 825131236, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3015) },
                    { 489504759, 455470879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2623), 451209745, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2624) },
                    { 489504759, 490433615, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2945), 799896686, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2947) },
                    { 489504759, 559391790, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2719), 677406394, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2720) },
                    { 489504759, 570696662, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2549), 542761365, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2550) },
                    { 489504759, 585891888, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2796), 890623052, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2798) },
                    { 489504759, 656753350, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2784), 972233024, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2785) },
                    { 489504759, 685171448, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3100), 306386129, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3101) },
                    { 489504759, 765880408, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2707), 569535264, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2708) },
                    { 489504759, 895193332, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2635), 759636731, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2636) },
                    { 489504759, 896693369, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2560), 240201404, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2561) },
                    { 489504759, 957077905, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2871), 590982562, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2872) },
                    { 615430181, 154347166, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7403), 634604374, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7404) },
                    { 615430181, 169484117, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7164), 925062343, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7165) },
                    { 615430181, 232360197, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7392), 346429867, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7393) },
                    { 615430181, 303677148, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7635), 132896927, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7636) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 615430181, 310220316, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7253), 340153665, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7254) },
                    { 615430181, 337333684, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7546), 570144449, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7547) },
                    { 615430181, 366891928, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7328), 259156652, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7329) },
                    { 615430181, 485408558, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6938), 575393729, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6939) },
                    { 615430181, 553094711, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7015), 288534682, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7016) },
                    { 615430181, 636676311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7480), 568198209, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7481) },
                    { 615430181, 657681151, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7026), 256165596, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7028) },
                    { 615430181, 664001206, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7101), 343947359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7102) },
                    { 615430181, 693432582, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7089), 491264525, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7090) },
                    { 615430181, 746098787, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7557), 790105365, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7558) },
                    { 615430181, 746635828, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6949), 267286813, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6950) },
                    { 615430181, 747860447, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7175), 567439239, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7176) },
                    { 615430181, 834678410, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7623), 137297248, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7624) },
                    { 615430181, 913558359, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7469), 289864758, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7470) },
                    { 615430181, 919500855, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7242), 148972314, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7243) },
                    { 615430181, 974014414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7316), 330733909, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7317) },
                    { 673804234, 209615096, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5412), 858641314, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5413) },
                    { 673804234, 225150809, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5713), 814428507, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5714) },
                    { 673804234, 248287879, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5486), 936614386, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5487) },
                    { 673804234, 254952851, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5475), 226474126, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5476) },
                    { 673804234, 260306259, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5549), 931455452, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5550) },
                    { 673804234, 296174611, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5787), 833406650, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5788) },
                    { 673804234, 322833279, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5849), 580180566, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5850) },
                    { 673804234, 331959960, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5321), 559486575, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5323) },
                    { 673804234, 340905184, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5397), 287047534, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5399) },
                    { 673804234, 409548673, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5247), 827197828, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5248) },
                    { 673804234, 434373207, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5335), 576002225, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5336) },
                    { 673804234, 462805017, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5701), 640911659, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5702) },
                    { 673804234, 571175333, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5184), 600268896, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5185) },
                    { 673804234, 581377268, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5258), 368011783, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5260) },
                    { 673804234, 591429218, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5561), 799104168, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5562) },
                    { 673804234, 713951802, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5775), 580353480, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5777) },
                    { 673804234, 761174709, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5169), 427675250, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5170) },
                    { 673804234, 766521353, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5623), 529047274, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5624) },
                    { 673804234, 862349087, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5634), 980607705, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5636) },
                    { 673804234, 882236221, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5860), 717854787, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5862) },
                    { 701538149, 195693467, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6665), 143512043, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6666) },
                    { 701538149, 224883527, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6654), 423435457, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6655) },
                    { 701538149, 378822134, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6294), 174521707, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6295) },
                    { 701538149, 397633729, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6730), 131943582, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6731) },
                    { 701538149, 402120139, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6133), 137113632, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6134) },
                    { 701538149, 502914296, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6283), 530711414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6284) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 701538149, 504038786, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6367), 888577045, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6368) },
                    { 701538149, 523556624, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6071), 971224945, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6072) },
                    { 701538149, 530904331, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6356), 205510160, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6357) },
                    { 701538149, 549836076, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6060), 773142015, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6061) },
                    { 701538149, 557820952, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6741), 664131683, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6743) },
                    { 701538149, 566357499, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6506), 652263806, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6507) },
                    { 701538149, 573962458, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6592), 506198616, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6593) },
                    { 701538149, 609573366, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6518), 880684258, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6519) },
                    { 701538149, 611109689, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6580), 378284511, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6582) },
                    { 701538149, 754853037, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6209), 558526337, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6210) },
                    { 701538149, 779484745, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6444), 337652374, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6445) },
                    { 701538149, 831848783, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6220), 785460419, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6221) },
                    { 701538149, 938150687, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6429), 439101431, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6431) },
                    { 701538149, 980229955, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6144), 668811407, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6145) },
                    { 794985958, 129420466, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8727), 806990361, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8728) },
                    { 794985958, 162782057, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8791), 393367245, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8792) },
                    { 794985958, 178285997, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8958), 640638595, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8960) },
                    { 794985958, 217333090, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9402), 150322532, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9404) },
                    { 794985958, 274690524, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8883), 992804119, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8884) },
                    { 794985958, 320836747, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8716), 805191929, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8717) },
                    { 794985958, 410585751, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9021), 316626637, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9022) },
                    { 794985958, 415010409, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9174), 181131642, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9176) },
                    { 794985958, 508473295, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9261), 464107218, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9262) },
                    { 794985958, 556937078, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9186), 566181319, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9187) },
                    { 794985958, 705530604, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9327), 915907150, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9329) },
                    { 794985958, 730339311, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9249), 676141163, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9250) },
                    { 794985958, 740615414, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9339), 714463366, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9340) },
                    { 794985958, 769949996, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9098), 624722556, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9100) },
                    { 794985958, 783342377, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9110), 398006165, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9111) },
                    { 794985958, 827785916, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9032), 881226416, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9033) },
                    { 794985958, 849016006, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9414), 720622471, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9415) },
                    { 794985958, 947132395, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8947), 161486127, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8948) },
                    { 794985958, 990812334, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8872), 160487941, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8873) },
                    { 794985958, 994713011, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8802), 423643152, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8803) },
                    { 797842216, 230606031, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9857), 129469439, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9858) },
                    { 797842216, 293070441, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9997), 955472645, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9998) },
                    { 797842216, 323780764, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9931), 699887900, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9933) },
                    { 797842216, 435690962, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(83), 301055079, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(84) },
                    { 797842216, 469081584, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9617), 843398912, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9618) },
                    { 797842216, 487893729, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(233), 425702501, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(234) },
                    { 797842216, 494593460, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9704), 340961597, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9705) },
                    { 797842216, 519506777, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9771), 162617256, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9772) }
                });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EmployeeId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 797842216, 539310697, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(145), 354483878, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(147) },
                    { 797842216, 542874168, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(71), 356614595, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(72) },
                    { 797842216, 600193144, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(219), 382392639, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(221) },
                    { 797842216, 605504845, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(157), 883530728, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(158) },
                    { 797842216, 689472878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9920), 445153793, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9921) },
                    { 797842216, 701684122, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(307), 361607868, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(309) },
                    { 797842216, 723493136, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9628), 351334667, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9630) },
                    { 797842216, 892732481, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9782), 138592931, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9783) },
                    { 797842216, 918998516, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9692), 563849987, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9693) },
                    { 797842216, 921296394, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(296), 155762915, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(297) },
                    { 797842216, 962334030, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9845), 877951796, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9847) },
                    { 797842216, 992706426, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(8), 615056915, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(9) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 174323694, 4, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8545), 265901953, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8546), 14.0, "Doc_7" },
                    { 194962034, 25, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3208), 489504759, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3210), 2.0, "Doc_1" },
                    { 205266626, 4, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7660), 615430181, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7661), 12.0, "Doc_6" },
                    { 222089805, 3, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9440), 794985958, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9441), 16.0, "Doc_8" },
                    { 401733835, 8, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5003), 336108878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5004), 6.0, "Doc_3" },
                    { 553471341, 5, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6767), 701538149, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6768), 10.0, "Doc_5" },
                    { 815392372, 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5885), 673804234, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5886), 8.0, "Doc_4" },
                    { 820220695, 3, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(334), 797842216, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(335), 18.0, "Doc_9" },
                    { 957962024, 12, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4109), 474679962, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4110), 4.0, "Doc_2" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "Completed", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 198081633, 4, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7646), 615430181, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7647), 18.0, "Draw_6" },
                    { 255262763, 8, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4989), 336108878, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4990), 9.0, "Draw_3" },
                    { 535438812, 12, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4095), 474679962, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4096), 6.0, "Draw_2" },
                    { 734449317, 6, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5872), 673804234, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5873), 12.0, "Draw_4" },
                    { 767695377, 3, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9425), 794985958, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9427), 24.0, "Draw_8" },
                    { 915301613, 5, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6753), 701538149, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6754), 15.0, "Draw_5" },
                    { 962524370, 4, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8531), 265901953, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8532), 21.0, "Draw_7" },
                    { 999088705, 3, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(319), 797842216, new DateTime(2024, 2, 20, 10, 56, 39, 62, DateTimeKind.Local).AddTicks(320), 27.0, "Draw_9" },
                    { 999902280, 25, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3185), 489504759, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3186), 3.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 182745993, 207727998, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6818), 267294489, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(6819) },
                    { 182745993, 223019398, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9489), 332965285, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(9490) },
                    { 182745993, 252830069, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7708), 804402845, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(7710) },
                    { 182745993, 337388796, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5050), 411450828, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5051) },
                    { 182745993, 470401103, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8594), 929747275, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(8596) },
                    { 182745993, 778268350, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2317), 949011287, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(2319) },
                    { 182745993, 810063655, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4162), 971176197, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(4163) },
                    { 182745993, 833534571, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3265), 259310591, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(3266) },
                    { 182745993, 967556265, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5937), 928130635, new DateTime(2024, 2, 20, 10, 56, 39, 61, DateTimeKind.Local).AddTicks(5938) }
                });

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
                name: "IX_Users_ProjectId",
                table: "Users",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
