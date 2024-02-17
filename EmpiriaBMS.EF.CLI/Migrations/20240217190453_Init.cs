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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Vat = table.Column<double>(type: "float", nullable: true),
                    Fee = table.Column<double>(type: "float", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                name: "ProjectEmployee",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
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
                    { "092a7ad5c1af440d90e69a311afa6f9a36", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4022), 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 25, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4022), new DateTime(2024, 4, 19, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4022), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4022), 24, "Project_6", 5.0, new DateTime(2024, 4, 26, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4022), "Payment Detailes For Project_30", 6.0, 1, 218 },
                    { "1979eb652f5942b9a626dc262f57802e0", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2957), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 7, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2957), new DateTime(2024, 4, 7, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2957), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2957), 0, "Project_0", 5.0, new DateTime(2024, 4, 8, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2957), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "19a7ceeac3a64225b523f9fa4704020442", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4183), 12.0, -72, 38, "Test Description Project_7", "KL-7", new DateTime(2024, 4, 28, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4183), new DateTime(2024, 4, 21, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4183), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4183), 28, "Project_7", 5.0, new DateTime(2024, 4, 29, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4183), "Payment Detailes For Project_35", 7.0, 0, 221 },
                    { "2f50bc95eefe4ef7a5010cb1bb7280985", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3841), 10.0, -66, 28, "Test Description Project_10", "KL-5", new DateTime(2024, 4, 22, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3841), new DateTime(2024, 4, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3841), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3841), 20, "Project_5", 5.0, new DateTime(2024, 4, 23, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3841), "Payment Detailes For Project_5", 5.0, 0, 215 },
                    { "37963bd92712463f8f9dd98060670f2e18", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3451), 8.0, -60, 18, "Test Description Project_15", "KL-3", new DateTime(2024, 4, 16, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 4, 13, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3451), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3451), 12, "Project_3", 5.0, new DateTime(2024, 4, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3451), "Payment Detailes For Project_18", 3.0, 0, 209 },
                    { "98860854fd7e41f68414910c2161eb494", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3146), 6.0, -54, 8, "Test Description Project_6", "KL-1", new DateTime(2024, 4, 10, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 4, 9, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3146), 4, "Project_1", 5.0, new DateTime(2024, 4, 11, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3146), "Payment Detailes For Project_3", 1.0, 0, 203 },
                    { "b407d0a5d297497392ddc24b0266a84512", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3712), 9.0, -63, 23, "Test Description Project_20", "KL-4", new DateTime(2024, 4, 19, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3712), new DateTime(2024, 4, 15, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3712), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3712), 16, "Project_4", 5.0, new DateTime(2024, 4, 20, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3712), "Payment Detailes For Project_4", 4.0, 1, 212 },
                    { "c179b725625c4bcfb9413bcd0488244e32", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4327), 13.0, -75, 43, "Test Description Project_40", "KL-8", new DateTime(2024, 5, 1, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4327), new DateTime(2024, 4, 23, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4327), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4327), 32, "Project_8", 5.0, new DateTime(2024, 5, 2, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4327), "Payment Detailes For Project_24", 8.0, 1, 224 },
                    { "d7a8dac9771649a69478180af68804698", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3321), 7.0, -57, 13, "Test Description Project_4", "KL-2", new DateTime(2024, 4, 13, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3321), new DateTime(2024, 4, 11, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3321), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3321), 8, "Project_2", 5.0, new DateTime(2024, 4, 14, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3321), "Payment Detailes For Project_12", 2.0, 1, 206 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "2cfbf82ecc1a4a0bbaa75f4e45c784af2", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2718), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2719), "Engineers" },
                    { "4aaef5f6e2a047fcabc6becc58d152c94", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2739), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2740), "COO" },
                    { "54266dfb487b410cbf9e67d442c0ed3f5", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2752), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2753), "CTO" },
                    { "70e97594d0464c59834f9566fcca13d53", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2728), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2729), "Project Managers" },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2782), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2783), "Customer" },
                    { "86a8f995885c4208b3a6768b0a0370887", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2772), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2773), "Guest" },
                    { "ca0a3812602d4e759f506f531f69130c6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2763), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2764), "CEO" },
                    { "dcfe36a2916c4577af6c95666984dee31", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2706), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2707), "Draftsmen" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "16be943f528a4e109841ba5413c47a5b6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3261), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3262), null, "6949277784", null, null, null },
                    { "3eea506610c04b65b98d13b664bf000a42", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4125), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4126), null, "6949277789", null, null, null },
                    { "7667ea76f25d4c75886164c475954eeb0", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2870), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2871), null, "6949277782", null, null, null },
                    { "88b2602f3bd046588cf9a857e6414ef13", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3114), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3115), null, "6949277783", null, null, null },
                    { "a8ef4419c9e24024b2119ea91bd53b6718", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3990), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3991), null, "6949277788", null, null, null },
                    { "ad75147f9a1f4ac998adf7b993bda1218", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4292), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4293), null, "69492777810", null, null, null },
                    { "d9c169d163124fe1a3fb5e442ef0c19120", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3657), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3658), null, "6949277786", null, null, null },
                    { "ebe452ef6ae045b7879b9d1d53f77b623", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3420), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3421), null, "6949277785", null, null, null },
                    { "f359b26ceefe43caaa39235159c314b715", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3807), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3808), null, "6949277787", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { "2abf0a753b7741af9fb7f97eb121bd2248", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4420), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4422), 100003000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4421), "Signature 142348", 13110, "c179b725625c4bcfb9413bcd0488244e32", 8.0, 24.0 },
                    { "2f5fd977d79e4d59b84d82ea2d13b28d18", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3631), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3633), 4000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3632), "Signature 1423415", 43051, "37963bd92712463f8f9dd98060670f2e18", 3.0, 17.0 },
                    { "33f0bc7c6fe84042a4f6f033125fa7216", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3393), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3395), 3100.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3394), "Signature 1423410", 85252, "d7a8dac9771649a69478180af68804698", 2.0, 24.0 },
                    { "4185612b79244b5f9d301c42fc249dfa30", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3967), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3969), 103000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3968), "Signature 142345", 36345, "2f50bc95eefe4ef7a5010cb1bb7280985", 5.0, 17.0 },
                    { "4f2a19dc94ac48a08bd6630ffaf384f86", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3239), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3242), 3010.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3241), "Signature 142342", 57429, "98860854fd7e41f68414910c2161eb494", 1.0, 17.0 },
                    { "50a9d4423bcf4aef8a501f90e520dff642", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4270), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4272), 10003000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4271), "Signature 1423435", 55721, "19a7ceeac3a64225b523f9fa4704020442", 7.0, 17.0 },
                    { "a8e09376b941439188308b539535b6f224", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3782), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3785), 13000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3783), "Signature 142344", 81926, "b407d0a5d297497392ddc24b0266a84512", 4.0, 24.0 },
                    { "c2d12651e71e4982b38da3717c3e08df0", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3071), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3073), 3001.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3072), "Signature 142340", 43370, "1979eb652f5942b9a626dc262f57802e0", 0.0, 24.0 },
                    { "dc40c0dd386e4b7a8ce1298fb66fedb418", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4104), new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4107), 1003000.0, new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4106), "Signature 1423436", 28327, "092a7ad5c1af440d90e69a311afa6f9a36", 6.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "EmployeeId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "3eea506610c04b65b98d13b664bf000a42", "19a7ceeac3a64225b523f9fa4704020442", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4211), "09642be95ab5484a9fa95c79bde319e842", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4213) },
                    { "f359b26ceefe43caaa39235159c314b715", "2f50bc95eefe4ef7a5010cb1bb7280985", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3896), "7f86bbc9347a4fe0bce96f10b2e62cdb30", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3897) },
                    { "ebe452ef6ae045b7879b9d1d53f77b623", "37963bd92712463f8f9dd98060670f2e18", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3480), "e3842849053240cd85995968da98b5c418", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3482) },
                    { "88b2602f3bd046588cf9a857e6414ef13", "98860854fd7e41f68414910c2161eb494", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3176), "daee682852864407a40b8ff2122bd1c44", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3177) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "70e97594d0464c59834f9566fcca13d53", "16be943f528a4e109841ba5413c47a5b6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3308), "019f2f33c7fb429ea3d74c76a55f389a", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3310) },
                    { "70e97594d0464c59834f9566fcca13d53", "3eea506610c04b65b98d13b664bf000a42", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4171), "e826095e953a4b3db7f7deaae7743f54", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4173) },
                    { "70e97594d0464c59834f9566fcca13d53", "7667ea76f25d4c75886164c475954eeb0", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2938), "b75972b5a76944ce968d99ffd1de9c51", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(2940) },
                    { "70e97594d0464c59834f9566fcca13d53", "88b2602f3bd046588cf9a857e6414ef13", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3135), "0b538be3b4714cf6a22e2903888556f5", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3136) },
                    { "70e97594d0464c59834f9566fcca13d53", "a8ef4419c9e24024b2119ea91bd53b6718", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4010), "60335b34dce44537a61918a49c900ea3", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4012) },
                    { "70e97594d0464c59834f9566fcca13d53", "ad75147f9a1f4ac998adf7b993bda1218", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4314), "7911d8d893274eab9f16f1bb725e9103", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4315) },
                    { "70e97594d0464c59834f9566fcca13d53", "d9c169d163124fe1a3fb5e442ef0c19120", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3700), "fe1b28f3acf44a449d6fb30580bdb9c7", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3701) },
                    { "70e97594d0464c59834f9566fcca13d53", "ebe452ef6ae045b7879b9d1d53f77b623", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3440), "1215c7f387144a689185c0ba15ffe8ec", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3441) },
                    { "70e97594d0464c59834f9566fcca13d53", "f359b26ceefe43caaa39235159c314b715", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3828), "36fd5990df774744b697069786ffbb7e", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3829) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "4594e791ff0d42c38a22bd622cb45bea42", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4230), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4231), null, "6949277787", null, null, "19a7ceeac3a64225b523f9fa4704020442" },
                    { "4cde91b22c034bddb9359533995975f424", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4052), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4053), null, "6949277786", null, null, "092a7ad5c1af440d90e69a311afa6f9a36" },
                    { "815a23939c484056b5a6295145316a072", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3199), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3201), null, "6949277781", null, null, "98860854fd7e41f68414910c2161eb494" },
                    { "92d2e1d63a7e49a09506b744856a5add6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3564), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3565), null, "6949277783", null, null, "37963bd92712463f8f9dd98060670f2e18" },
                    { "ae3bd06b892e45d490e2116caaefad800", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3024), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3026), null, "6949277780", null, null, "1979eb652f5942b9a626dc262f57802e0" },
                    { "be901d40ee554f5590c340b6a941779848", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4381), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4382), null, "6949277788", null, null, "c179b725625c4bcfb9413bcd0488244e32" },
                    { "c6735b200ee24c7d94ee5d334793ff0210", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3351), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3352), null, "6949277782", null, null, "d7a8dac9771649a69478180af68804698" },
                    { "cd903da4c12c4cb89403faef19b4848b15", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3915), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3916), null, "6949277785", null, null, "2f50bc95eefe4ef7a5010cb1bb7280985" },
                    { "ee1d258ecbaa4c29a44f28b08630d5574", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3741), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3743), null, "6949277784", null, null, "b407d0a5d297497392ddc24b0266a84512" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "4594e791ff0d42c38a22bd622cb45bea42", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4252), "1f3af12a81b9407c833d0f964766c84c", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4253) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "4cde91b22c034bddb9359533995975f424", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4086), "2974538294274494830943c74ba1af62", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4087) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "815a23939c484056b5a6295145316a072", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3221), "8f1ae8886a4848b3887bc242d40dbf4f", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3222) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "92d2e1d63a7e49a09506b744856a5add6", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3586), "87db88bec61d48e3bdf1e291066392f7", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3588) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "ae3bd06b892e45d490e2116caaefad800", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3051), "d46c867bc60d4611b809d07f7c9591da", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3052) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "be901d40ee554f5590c340b6a941779848", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4402), "e34fafc76a2f4b269d6f248e9df5bd86", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(4403) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "c6735b200ee24c7d94ee5d334793ff0210", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3373), "9165f247cbc14e72b8d0ca1f7bde839d", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3374) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "cd903da4c12c4cb89403faef19b4848b15", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3947), "03a194bd08f54a1ba34cf1e7e3dcbe1d", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3948) },
                    { "7eff7e238d5a462283fd03fb72a7a5fa8", "ee1d258ecbaa4c29a44f28b08630d5574", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3764), "35b8b78f322d4311a3d193d079f5e8fe", new DateTime(2024, 2, 17, 21, 4, 53, 433, DateTimeKind.Local).AddTicks(3765) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
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
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
