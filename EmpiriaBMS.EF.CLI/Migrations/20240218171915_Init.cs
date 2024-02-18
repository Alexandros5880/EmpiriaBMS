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
                    PlanType = table.Column<int>(type: "int", nullable: false),
                    WorkingDays = table.Column<int>(type: "int", nullable: true),
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
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinesEngineer", x => new { x.DisciplineId, x.EngineerId });
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinesEngineer_Users_EngineerId",
                        column: x => x.EngineerId,
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
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { 138668894, "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4528), 10.0, -66, 28, "Test Description Project_20", "KL-5", new DateTime(2024, 4, 23, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4528), new DateTime(2024, 4, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4528), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4528), 20, "Project_5", 5.0, new DateTime(2024, 4, 24, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4528), "Payment Detailes For Project_10", 5.0, 0, 215 },
                    { 238778979, "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5137), 13.0, -75, 43, "Test Description Project_32", "KL-8", new DateTime(2024, 5, 2, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5137), new DateTime(2024, 4, 24, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5137), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5137), 32, "Project_8", 5.0, new DateTime(2024, 5, 3, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5137), "Payment Detailes For Project_8", 8.0, 1, 224 },
                    { 448570497, "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3680), 6.0, -54, 8, "Test Description Project_2", "KL-1", new DateTime(2024, 4, 11, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3680), new DateTime(2024, 4, 10, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3680), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3680), 4, "Project_1", 5.0, new DateTime(2024, 4, 12, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3680), "Payment Detailes For Project_6", 1.0, 0, 203 },
                    { 463455076, "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4736), 11.0, -69, 33, "Test Description Project_36", "KL-6", new DateTime(2024, 4, 26, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4736), new DateTime(2024, 4, 20, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4736), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4736), 24, "Project_6", 5.0, new DateTime(2024, 4, 27, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4736), "Payment Detailes For Project_18", 6.0, 1, 218 },
                    { 493528078, "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4318), 9.0, -63, 23, "Test Description Project_12", "KL-4", new DateTime(2024, 4, 20, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4318), new DateTime(2024, 4, 16, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4318), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4318), 16, "Project_4", 5.0, new DateTime(2024, 4, 21, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4318), "Payment Detailes For Project_12", 4.0, 1, 212 },
                    { 568325031, "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4111), 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 17, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4111), new DateTime(2024, 4, 14, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4111), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4111), 12, "Project_3", 5.0, new DateTime(2024, 4, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4111), "Payment Detailes For Project_15", 3.0, 0, 209 },
                    { 715611564, "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3347), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 8, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3347), new DateTime(2024, 4, 8, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3347), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3347), 0, "Project_0", 5.0, new DateTime(2024, 4, 9, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3347), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { 741153499, "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4938), 12.0, -72, 38, "Test Description Project_14", "KL-7", new DateTime(2024, 4, 29, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4938), new DateTime(2024, 4, 22, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4938), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4938), 28, "Project_7", 5.0, new DateTime(2024, 4, 30, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4938), "Payment Detailes For Project_14", 7.0, 0, 221 },
                    { 750637520, "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3897), 7.0, -57, 13, "Test Description Project_4", "KL-2", new DateTime(2024, 4, 14, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3897), new DateTime(2024, 4, 12, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3897), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3897), 8, "Project_2", 5.0, new DateTime(2024, 4, 15, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3897), "Payment Detailes For Project_10", 2.0, 1, 206 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEmployee", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 185205596, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3184), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3185), "Project Managers" },
                    { 250469691, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3219), false, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3221), "Guest" },
                    { 477335804, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3193), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3194), "COO" },
                    { 500840904, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3163), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3165), "Draftsmen" },
                    { 580514221, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3202), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3204), "CTO" },
                    { 646599759, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3228), false, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3229), "Customer" },
                    { 783469795, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3175), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3176), "Engineers" },
                    { 982815245, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3211), true, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3212), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 194242074, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3764), "Test Description Employee 3", null, "alexpl_22@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3765), null, "6949277783", null, null, null },
                    { 324614783, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3802), "Test Description Employee 3", null, "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3803), null, "6949277783", null, null, null },
                    { 338217635, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4608), "Test Description Employee 7", null, "alexpl_26@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4610), null, "6949277787", null, null, null },
                    { 359402976, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4644), "Test Description Employee 7", null, "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4645), null, "6949277787", null, null, null },
                    { 401245866, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5013), "Test Description Employee 9", null, "alexpl_28@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5015), null, "6949277789", null, null, null },
                    { 412468490, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3548), "Test Description Employee 2", null, "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3549), null, "6949277782", null, null, null },
                    { 419958779, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4018), "Test Description Employee 4", null, "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4019), null, "6949277784", null, null, null },
                    { 528471487, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4845), "Test Description Employee 8", null, "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4847), null, "6949277788", null, null, null },
                    { 610998788, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4400), "Test Description Employee 6", null, "alexpl_25@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4401), null, "6949277786", null, null, null },
                    { 675538759, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3983), "Test Description Employee 4", null, "alexpl_23@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3984), null, "6949277784", null, null, null },
                    { 880646834, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5259), "Test Description Employee 10", null, "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5260), null, "69492777810", null, null, null },
                    { 882449705, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3506), "Test Description Employee 2", null, "alexpl_21@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3507), null, "6949277782", null, null, null },
                    { 910425835, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4224), "Test Description Employee 5", null, "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4226), null, "6949277785", null, null, null },
                    { 914472811, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4434), "Test Description Employee 6", null, "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4435), null, "6949277786", null, null, null },
                    { 915910407, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5047), "Test Description Employee 9", null, "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5048), null, "6949277789", null, null, null },
                    { 916865424, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4812), "Test Description Employee 8", null, "alexpl_27@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4813), null, "6949277788", null, null, null },
                    { 917410259, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4189), "Test Description Employee 5", null, "alexpl_24@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4190), null, "6949277785", null, null, null },
                    { 974098511, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5223), "Test Description Employee 10", null, "alexpl_29@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5225), null, "69492777810", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "ProjectId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 234083652, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3588), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3589), "HVAC", 715611564, 882449705 },
                    { 358964667, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4054), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4056), "HVAC", 750637520, 675538759 },
                    { 478720087, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5080), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5081), "ELEC", 741153499, 401245866 },
                    { 533024446, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4258), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4259), "ELEC", 568325031, 917410259 },
                    { 701031954, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4467), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4468), "HVAC", 493528078, 610998788 },
                    { 779139327, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3837), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3838), "ELEC", 448570497, 194242074 },
                    { 821230563, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4880), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4881), "HVAC", 463455076, 916865424 },
                    { 903131476, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5294), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5295), "HVAC", 238778979, 974098511 },
                    { 943404038, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4677), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4679), "ELEC", 138668894, 338217635 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 403772250, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4169), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4171), 4000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4170), "Signature 1423415", 10860, 568325031, 3.0, 17.0 },
                    { 438256150, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4588), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4590), 103000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4589), "Signature 142345", 47996, 138668894, 5.0, 17.0 },
                    { 513908488, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4379), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4382), 13000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4380), "Signature 142344", 65582, 493528078, 4.0, 24.0 },
                    { 518694235, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4796), 1003000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4794), "Signature 1423418", 67014, 463455076, 6.0, 24.0 },
                    { 523792813, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3472), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3475), 3001.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3473), "Signature 142340", 84819, 715611564, 0.0, 24.0 },
                    { 557811801, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3743), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3746), 3010.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3745), "Signature 142346", 74922, 448570497, 1.0, 17.0 },
                    { 629318984, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4995), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4998), 10003000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4996), "Signature 1423414", 66763, 741153499, 7.0, 17.0 },
                    { 658452035, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5198), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5200), 100003000.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5199), "Signature 1423416", 69593, 238778979, 8.0, 24.0 },
                    { 689389620, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3957), new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3960), 3100.0, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3958), "Signature 142342", 27975, 750637520, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 185205596, 194242074, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3785), 828573721, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3787) },
                    { 783469795, 324614783, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3822), 499637115, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3823) },
                    { 185205596, 338217635, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4628), 151734635, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4629) },
                    { 783469795, 359402976, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4663), 483643477, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4664) },
                    { 185205596, 401245866, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5032), 482879901, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5033) },
                    { 783469795, 412468490, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3571), 219679779, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3573) },
                    { 783469795, 419958779, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4038), 858802421, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4040) },
                    { 783469795, 528471487, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4865), 580109641, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4866) },
                    { 185205596, 610998788, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4419), 807446594, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4420) },
                    { 185205596, 675538759, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4003), 876352471, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4004) },
                    { 783469795, 880646834, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5279), 820589978, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5281) },
                    { 185205596, 882449705, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3531), 496679428, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3533) },
                    { 783469795, 910425835, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4243), 678773179, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4245) },
                    { 783469795, 914472811, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4453), 352017936, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4454) },
                    { 783469795, 915910407, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5065), 375827667, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5066) },
                    { 185205596, 916865424, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4830), 348962874, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4832) },
                    { 185205596, 917410259, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4209), 192231584, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4211) },
                    { 185205596, 974098511, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5244), 751496018, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5245) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { 137798425, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4760), "Test Description Client 6", null, "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4761), null, "6949277786", null, null, 463455076 },
                    { 316004911, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3708), "Test Description Client 1", null, "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3709), null, "6949277781", null, null, 448570497 },
                    { 344697142, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5164), "Test Description Client 8", null, "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5165), null, "6949277788", null, null, 238778979 },
                    { 510991788, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3922), "Test Description Client 2", null, "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3924), null, "6949277782", null, null, 750637520 },
                    { 679474340, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4553), "Test Description Client 5", null, "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4555), null, "6949277785", null, null, 138668894 },
                    { 690029598, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4962), "Test Description Client 7", null, "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4963), null, "6949277787", null, null, 741153499 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 731736439, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4136), "Test Description Client 3", null, "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4137), null, "6949277783", null, null, 568325031 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 763211220, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3400), "Test Description Client 0", null, "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3402), null, "6949277780", null, null, 715611564 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "DisciplineId", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[] { 921723374, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4344), "Test Description Client 4", null, "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4346), null, "6949277784", null, null, 493528078 });

            migrationBuilder.InsertData(
                table: "DisciplinesEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 234083652, 412468490, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3611), 744940138, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3613) },
                    { 358964667, 419958779, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4069), 417329750, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4071) },
                    { 478720087, 915910407, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5094), 741232764, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5096) },
                    { 533024446, 910425835, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4273), 982919869, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4274) },
                    { 701031954, 914472811, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4483), 618670582, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4484) },
                    { 779139327, 324614783, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3853), 790760092, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3854) },
                    { 821230563, 528471487, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4895), 156128836, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4896) },
                    { 903131476, 880646834, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5310), 506229822, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5311) },
                    { 943404038, 359402976, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4693), 369216567, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4694) }
                });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 144356692, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5125), 478720087, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5126), 21.0, "Draw_1" },
                    { 316754440, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5343), 903131476, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5345), 24.0, "Draw_1" },
                    { 342427123, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3662), 234083652, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3663), 0.0, "Draw_1" },
                    { 659854728, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4307), 533024446, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4308), 3.0, "Draw_1" },
                    { 686368075, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4927), 821230563, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4928), 12.0, "Draw_1" },
                    { 696534768, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3884), 779139327, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3886), 1.0, "Draw_1" },
                    { 902483839, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4724), 943404038, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4726), 5.0, "Draw_1" },
                    { 929222132, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4516), 701031954, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4517), 16.0, "Draw_1" },
                    { 995869077, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4100), 358964667, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4101), 6.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "CreatedDate", "DisciplineId", "LastUpdatedDate", "ManHours", "Name" },
                values: new object[,]
                {
                    { 288561714, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5326), 903131476, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5327), 24.0, "Draw_1" },
                    { 405745297, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4911), 821230563, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4913), 12.0, "Draw_1" },
                    { 473959995, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3867), 779139327, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3869), 3.0, "Draw_1" },
                    { 486063370, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5109), 478720087, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5111), 14.0, "Draw_1" },
                    { 499299728, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4499), 701031954, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4500), 16.0, "Draw_1" },
                    { 721498226, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4288), 533024446, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4289), 12.0, "Draw_1" },
                    { 810578028, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3637), 234083652, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3639), 0.0, "Draw_1" },
                    { 939971878, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4084), 358964667, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4085), 2.0, "Draw_1" },
                    { 973062275, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4708), 943404038, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4709), 15.0, "Draw_1" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 646599759, 137798425, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4778), 752228537, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4780) },
                    { 646599759, 316004911, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3728), 284326286, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3730) },
                    { 646599759, 344697142, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5183), 564932544, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(5184) },
                    { 646599759, 510991788, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3941), 963567236, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3943) },
                    { 646599759, 679474340, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4572), 380975045, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4574) },
                    { 646599759, 690029598, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4980), 879443579, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4981) },
                    { 646599759, 731736439, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4154), 376986600, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4155) },
                    { 646599759, 763211220, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3450), 202334410, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(3451) },
                    { 646599759, 921723374, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4364), 258060837, new DateTime(2024, 2, 18, 19, 19, 15, 415, DateTimeKind.Local).AddTicks(4365) }
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
                name: "IX_DisciplinesEngineer_EngineerId",
                table: "DisciplinesEngineer",
                column: "EngineerId");

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
