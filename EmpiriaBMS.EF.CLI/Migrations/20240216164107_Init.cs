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
                    { "25fb2a43fd3348e1a24247802b857ece30", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4686), 10.0, -66, 28, "Test Description Project_30", "KL-5", new DateTime(2024, 4, 21, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4686), new DateTime(2024, 4, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4686), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4686), 20, "Project_5", 5.0, new DateTime(2024, 4, 22, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4686), "Payment Detailes For Project_15", 5.0, 0, 215 },
                    { "272f577cc6974d3a940c5be57ccbafea15", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4397), 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 15, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4397), new DateTime(2024, 4, 12, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4397), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4397), 12, "Project_3", 5.0, new DateTime(2024, 4, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4397), "Payment Detailes For Project_3", 3.0, 0, 209 },
                    { "4755aad31e0245109e7a538793a5c7b020", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4554), 9.0, -63, 23, "Test Description Project_20", "KL-4", new DateTime(2024, 4, 18, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4554), new DateTime(2024, 4, 14, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4554), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4554), 16, "Project_4", 5.0, new DateTime(2024, 4, 19, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4554), "Payment Detailes For Project_12", 4.0, 1, 212 },
                    { "584919ef63344b8a94237769df47c70d8", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4263), 7.0, -57, 13, "Test Description Project_4", "KL-2", new DateTime(2024, 4, 12, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4263), new DateTime(2024, 4, 10, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4263), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4263), 8, "Project_2", 5.0, new DateTime(2024, 4, 13, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4263), "Payment Detailes For Project_6", 2.0, 1, 206 },
                    { "ad64de47c68742af859375dd2442323232", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5139), 13.0, -75, 43, "Test Description Project_16", "KL-8", new DateTime(2024, 4, 30, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5139), new DateTime(2024, 4, 22, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5139), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5139), 32, "Project_8", 5.0, new DateTime(2024, 5, 1, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5139), "Payment Detailes For Project_32", 8.0, 1, 224 },
                    { "ba280a61250f46859cd96fb424b8fcf60", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3943), 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 6, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3943), new DateTime(2024, 4, 6, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3943), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3943), 0, "Project_0", 5.0, new DateTime(2024, 4, 7, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3943), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "ed1084ae9f3f43f6a5049641460dcd7242", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4987), 12.0, -72, 38, "Test Description Project_42", "KL-7", new DateTime(2024, 4, 27, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4987), new DateTime(2024, 4, 20, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4987), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4987), 28, "Project_7", 5.0, new DateTime(2024, 4, 28, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4987), "Payment Detailes For Project_28", 7.0, 0, 221 },
                    { "f8e74e8e46d9496ab8b2078a689246003", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4107), 6.0, -54, 8, "Test Description Project_5", "KL-1", new DateTime(2024, 4, 9, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4107), new DateTime(2024, 4, 8, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4107), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4107), 4, "Project_1", 5.0, new DateTime(2024, 4, 10, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4107), "Payment Detailes For Project_2", 1.0, 0, 203 },
                    { "fa451855604849b69f67a932eedd59106", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4840), 11.0, -69, 33, "Test Description Project_18", "KL-6", new DateTime(2024, 4, 24, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4840), new DateTime(2024, 4, 18, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4840), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4840), 24, "Project_6", 5.0, new DateTime(2024, 4, 25, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4840), "Payment Detailes For Project_36", 6.0, 1, 218 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "342a51ea1b4645de98503b7932ded88d2", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3722), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3723), "Engineers" },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3786), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3787), "Customer" },
                    { "478292d84f234feb846897725d3974481", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3709), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3710), "Draftsmen" },
                    { "67c074603b6e4fc7a3b24c77d66fe9bc7", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3776), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3777), "Guest" },
                    { "7a6166f9e2e9456997e5672d832df2576", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3766), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3767), "CEO" },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3733), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3734), "Project Managers" },
                    { "b359d8fee5c14a2494e31d19e61416f54", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3743), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3744), "COO" },
                    { "d06b40198d594a04a2ef343afa7148935", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3753), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3755), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "09251b31ab5a450b8d2ea2f5da44bb994", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4073), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4074), null, "6949277783", null, null, null },
                    { "39a3d77fc8784eb0a9a83194688bb7320", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3874), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3875), null, "6949277782", null, null, null },
                    { "41fb7454b6d84b90bd89e9257421631824", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5104), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5105), null, "69492777810", null, null, null },
                    { "4f69566b6dde4a2fb1f368c2e5a0c58310", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4225), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4226), null, "6949277784", null, null, null },
                    { "51e4b416d79c4e5fb0e9d3cbf502871925", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4653), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4654), null, "6949277787", null, null, null },
                    { "52b6f3e5976947daaaa63acb1dafed3316", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4515), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4516), null, "6949277786", null, null, null },
                    { "5404f85bd9ae46bea7a739b4fd731d6c12", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4808), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4809), null, "6949277788", null, null, null },
                    { "6449916933a145fa95198dc3a21e6b3342", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4953), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4954), null, "6949277789", null, null, null },
                    { "6f202b3b07104c90ac3c6361b4807a9b3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4364), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4365), null, "6949277785", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { "4246dc1dabb54777b9ce985c29bb827d10", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4342), 3100.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4341), "Signature 142344", 66898, "584919ef63344b8a94237769df47c70d8", 2.0, 24.0 },
                    { "4602902e462d449a8eba293c5c51fd1d10", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4785), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4787), 103000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4786), "Signature 1423425", 39267, "25fb2a43fd3348e1a24247802b857ece30", 5.0, 17.0 },
                    { "5d512258bd6c4870aacc7a35bd1a186812", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4490), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4492), 4000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4491), "Signature 142346", 76090, "272f577cc6974d3a940c5be57ccbafea15", 3.0, 17.0 },
                    { "711863f512f443889e8ea7c2fe339e1928", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5084), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5086), 10003000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5085), "Signature 1423421", 82009, "ed1084ae9f3f43f6a5049641460dcd7242", 7.0, 17.0 },
                    { "7f35f6619de2495ab70f60b31102f78e20", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4629), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4631), 13000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4630), "Signature 142344", 72735, "4755aad31e0245109e7a538793a5c7b020", 4.0, 24.0 },
                    { "b3bb6fd1b1d54e02a7a4747eb62db8640", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4036), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4038), 3001.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4037), "Signature 142340", 42210, "ba280a61250f46859cd96fb424b8fcf60", 0.0, 24.0 },
                    { "b606eacf1f1640d894112b610cbfeb044", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4203), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4205), 3010.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4204), "Signature 142342", 83962, "f8e74e8e46d9496ab8b2078a689246003", 1.0, 17.0 },
                    { "cafa3b718f184999a5624caf22a49c4f24", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4931), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4933), 1003000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4932), "Signature 1423436", 39624, "fa451855604849b69f67a932eedd59106", 6.0, 24.0 },
                    { "d368bd824af24d60bb8c21b0fb5a606540", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5214), new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5217), 100003000.0, new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5215), "Signature 1423448", 10125, "ad64de47c68742af859375dd2442323232", 8.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "EmployeeId", "ProjectId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "51e4b416d79c4e5fb0e9d3cbf502871925", "25fb2a43fd3348e1a24247802b857ece30", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4719), "263c612537af465394b8df507db3bf8115", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4721) },
                    { "6f202b3b07104c90ac3c6361b4807a9b3", "272f577cc6974d3a940c5be57ccbafea15", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4429), "a59124711253452692d26cb315a12e0d3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4430) },
                    { "6449916933a145fa95198dc3a21e6b3342", "ed1084ae9f3f43f6a5049641460dcd7242", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5021), "d0752ea6146f4485bc6ddbb375ced3bb7", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5022) },
                    { "09251b31ab5a450b8d2ea2f5da44bb994", "f8e74e8e46d9496ab8b2078a689246003", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4138), "76225609085e448490781a878448c2986", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4139) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "09251b31ab5a450b8d2ea2f5da44bb994", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4096), "1e2b8bac617749bba1ce10e0831b37e7", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4097) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "39a3d77fc8784eb0a9a83194688bb7320", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3927), "fcb200741c1c45879f54069b3a1da61b", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3928) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "41fb7454b6d84b90bd89e9257421631824", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5127), "62653fa23c08453c99ed028eebc64931", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5128) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "4f69566b6dde4a2fb1f368c2e5a0c58310", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4250), "bec56e7761824668b4610fdea6e03f90", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4252) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "51e4b416d79c4e5fb0e9d3cbf502871925", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4675), "37177ddaaea34f5abe8298ed96fc9d3e", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4676) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "52b6f3e5976947daaaa63acb1dafed3316", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4541), "e58c432898b44e2cb78eb9ae56c59f87", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4542) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "5404f85bd9ae46bea7a739b4fd731d6c12", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4829), "5cd1ab6b965840d68fb77ab0654327ca", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4830) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "6449916933a145fa95198dc3a21e6b3342", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4977), "e15d67d6c81c484b8ed91eb42d15e2b9", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4978) },
                    { "86a16dbc56cf45fbb6c9788589e8d0ee3", "6f202b3b07104c90ac3c6361b4807a9b3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4385), "58197082e660478fbff9797343dc9e36", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4386) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId" },
                values: new object[,]
                {
                    { "04d453e5879e490e8279fed3fae74e676", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4297), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4298), null, "6949277782", null, null, "584919ef63344b8a94237769df47c70d8" },
                    { "1cdb5ae6eb8142408d3720de6549b9760", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3985), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(3986), null, "6949277780", null, null, "ba280a61250f46859cd96fb424b8fcf60" },
                    { "747afa4e067b42efbf9a391aa9ea5eb718", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4872), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4873), null, "6949277786", null, null, "fa451855604849b69f67a932eedd59106" },
                    { "951ad8ff2b204469bbfd8e380cdb22611", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4162), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4163), null, "6949277781", null, null, "f8e74e8e46d9496ab8b2078a689246003" },
                    { "9b6bf3f670a4404bb1b8ebbb35ca283616", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4586), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4587), null, "6949277784", null, null, "4755aad31e0245109e7a538793a5c7b020" },
                    { "a20b6b05ae4a4bdbaa0b4c1021df148114", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5042), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5043), null, "6949277787", null, null, "ed1084ae9f3f43f6a5049641460dcd7242" },
                    { "a6d958a9dcdd4e0f86917e75a6a04ea224", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5172), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5173), null, "6949277788", null, null, "ad64de47c68742af859375dd2442323232" },
                    { "d697a63d059b4508975661dc6ee4585220", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4742), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4743), null, "6949277785", null, null, "25fb2a43fd3348e1a24247802b857ece30" },
                    { "dbe3c5c2372948b792985483cca8de7212", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4449), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4450), null, "6949277783", null, null, "272f577cc6974d3a940c5be57ccbafea15" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "04d453e5879e490e8279fed3fae74e676", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4319), "62258a159dbc4f3489d7674baf3c2d68", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4320) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "1cdb5ae6eb8142408d3720de6549b9760", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4014), "6103297522134e12af5d57169347e336", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4016) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "747afa4e067b42efbf9a391aa9ea5eb718", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4911), "0d155aaf015747ddb2e4a4f57dc4656f", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4912) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "951ad8ff2b204469bbfd8e380cdb22611", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4184), "b63a151b6d88457f9a2161bab4ca28ff", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4185) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "9b6bf3f670a4404bb1b8ebbb35ca283616", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4610), "356e4295b7d54e4990333be814802f14", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4611) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "a20b6b05ae4a4bdbaa0b4c1021df148114", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5065), "629f29f858b84c358ee6ced376f0026e", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5066) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "a6d958a9dcdd4e0f86917e75a6a04ea224", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5194), "bcdf672c1f494ce1b55eeb67e9982724", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(5195) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "d697a63d059b4508975661dc6ee4585220", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4764), "de047426e1e346a0a6472ca471b526ef", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4765) },
                    { "45cb3e59f2bc4fe3aecf9eaaafba3deb8", "dbe3c5c2372948b792985483cca8de7212", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4471), "b513afda16a243db860aa2ceb38d5441", new DateTime(2024, 2, 16, 18, 41, 6, 922, DateTimeKind.Local).AddTicks(4472) }
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
