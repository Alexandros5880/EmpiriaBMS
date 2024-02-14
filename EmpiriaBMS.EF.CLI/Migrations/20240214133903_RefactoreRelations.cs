using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class RefactoreRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "1423410");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142342");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142343");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25460");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25461");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25462");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25463");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25464");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25465");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25466");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25467");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25468");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "25469");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142344");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142345");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142346");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142347");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142348");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "142349");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Completed",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

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
                    ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => x.Id);
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
                name: "ProjectUser",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
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
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { "0fa459153a544c6680598e0b2c54cc9b8", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100003000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6826), "Signature 142348", 72956, null, 8.0, 24.0 },
                    { "1e29b160ddbc434a826dbd5ec382f9bd15", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6354), "Signature 142349", 10425, null, 3.0, 17.0 },
                    { "21681a4ebc5e424492bef876b72d24136", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6658), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1003000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6659), "Signature 1423436", 70556, null, 6.0, 24.0 },
                    { "596bb28b024d43ff9478522e9ac8ea6130", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6540), "Signature 1423410", 45703, null, 5.0, 17.0 },
                    { "8b76517f14bf4fa69dde98fa90e0d2a90", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1589), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3001.0, new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1591), "Signature 142340", 81695, null, 0.0, 24.0 },
                    { "a08fa229c6ed49dd9229b1ced57f0ea112", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6445), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6446), "Signature 1423416", 56839, null, 4.0, 24.0 },
                    { "a73a45ededf94841854d83793690602b6", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6227), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3100.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6228), "Signature 142348", 19960, null, 2.0, 24.0 },
                    { "c4f6e80cd2ec458589f0764fc5f4eec921", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10003000.0, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6738), "Signature 1423442", 60899, null, 7.0, 17.0 },
                    { "ef1bc388564c465895f7141a62fa43584", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1722), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3010.0, new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1723), "Signature 142341", 78786, null, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "336a182751df44d9a5b94e3d4e3c1e9c4", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6027), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6028), "COO" },
                    { "5a1abdb385b04c26b8048acbaa51d5821", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(5981), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6018), "Draftsmen" },
                    { "5b8e6e409d6c4673bcddfa84f1e3053f3", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6023), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6025), "Project Managers" },
                    { "6ecbad0f14f94e49bc0bbfd043e119187", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6036), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6038), "Guest" },
                    { "7f06316b735a4935b44afc3939946e1f8", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6039), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6041), "Customer" },
                    { "a329142f0ef74ca1a4109d3123cc2bad2", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6022), "Engineers" },
                    { "c67bdf35f73e4b5987351ecd8ce05c726", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6033), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6035), "CEO" },
                    { "e50b320011e54694badb0bff04f72c555", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6030), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6031), "CTO" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { "00d2c7541c9e407594c8225a32d723d924", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6393), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", null, "Alexandros_4", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6395), null, "6949277784", null, null, null, null },
                    { "11dc09596d77416aaec4b90fd7b0620920", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6502), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 40.0, "Alexandros_7", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6503), null, "6949277787", null, null, null, null },
                    { "27ec8b42d0fa4f4f945590b56417770748", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6797), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 64.0, "Alexandros_10", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6798), null, "69492777810", null, null, null, null },
                    { "3a5ea2459dcb43348fd86a60195dfd9712", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6056), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", null, "Alexandros_2", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6084), null, "6949277782", null, null, null, null },
                    { "4403d082880b40fcb5a2ab02c01785ae16", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6419), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 32.0, "Alexandros_6", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6421), null, "6949277786", null, null, null, null },
                    { "497a6694aca14decaa1092455020ac746", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6579), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", null, "Alexandros_6", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6580), null, "6949277786", null, null, null, null },
                    { "4bc28f5a578f4e45bfbfe5c8cb77c16f12", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6604), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 48.0, "Alexandros_8", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6605), null, "6949277788", null, null, null, null },
                    { "76b470a9fded4f96b8b36a999801f9146", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6305), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 24.0, "Alexandros_5", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6306), null, "6949277785", null, null, null, null },
                    { "8100f5c6c8aa4599a289f6e8e765afa39", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6280), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", null, "Alexandros_3", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6282), null, "6949277783", null, null, null, null },
                    { "8a684c7680ad4fd49df9089231783b7c2", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1692), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 8.0, "Alexandros_3", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1693), null, "6949277783", null, null, null, null },
                    { "8b1026aa4eff4ca9ba6e24038c60e39b6", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1652), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", null, "Alexandros_1", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1654), null, "6949277781", null, null, null, null },
                    { "a92145c5a060417e89dd6874d8a6a16535", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6712), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 56.0, "Alexandros_9", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6714), null, "6949277789", null, null, null, null },
                    { "b602ced735fc44f2aabd956b935aaea616", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6772), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", null, "Alexandros_8", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6774), null, "6949277788", null, null, null, null },
                    { "bda306cc98a840938f1dfac119a8e46d28", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6682), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", null, "Alexandros_7", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6684), null, "6949277787", null, null, null, null },
                    { "d1ed60f559ee4fd89be7360ccbd898506", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6194), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 16.0, "Alexandros_4", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6196), null, "6949277784", null, null, null, null },
                    { "dce2568cf3dc4f7abe7b5ba363a486130", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6124), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", null, "Alexandros_0", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6125), null, "6949277780", null, null, null, null },
                    { "de475d60b78e4c67a563e46f65e281bd25", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6474), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", null, "Alexandros_5", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6476), null, "6949277785", null, null, null, null },
                    { "e401d2ffebad441d99b404b94cc2112a0", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1454), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1486), null, "6949277782", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "01d5dcbba33541e7835112ea013c37806", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6366), null, 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 13, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6366), new DateTime(2024, 4, 10, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6366), "1e29b160ddbc434a826dbd5ec382f9bd15", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6366), 12, "Project_3", 5.0, new DateTime(2024, 4, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6366), "Payment Detailes For Project_3", 3.0, 0, 209 },
                    { "0271aea1bbe54681b446bfe897e0ad527", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6748), null, 12.0, -72, 38, "Test Description Project_28", "KL-7", new DateTime(2024, 4, 25, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6748), new DateTime(2024, 4, 18, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6748), "c4f6e80cd2ec458589f0764fc5f4eec921", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6748), 28, "Project_7", 5.0, new DateTime(2024, 4, 26, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6748), "Payment Detailes For Project_7", 7.0, 0, 221 },
                    { "2e7dde7cb7864dd2a5a5724320f27b8418", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6670), "497a6694aca14decaa1092455020ac746", 11.0, -69, 33, "Test Description Project_24", "KL-6", new DateTime(2024, 4, 22, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6670), new DateTime(2024, 4, 16, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6670), "21681a4ebc5e424492bef876b72d24136", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6670), 24, "Project_6", 5.0, new DateTime(2024, 4, 23, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6670), "Payment Detailes For Project_18", 6.0, 1, 218 },
                    { "69656e1794c74124a87d40a952a3e17d8", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6460), "00d2c7541c9e407594c8225a32d723d924", 9.0, -63, 23, "Test Description Project_12", "KL-4", new DateTime(2024, 4, 16, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6460), new DateTime(2024, 4, 12, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6460), "a08fa229c6ed49dd9229b1ced57f0ea112", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6460), 16, "Project_4", 5.0, new DateTime(2024, 4, 17, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6460), "Payment Detailes For Project_16", 4.0, 1, 212 },
                    { "89ee9f59233249eb8c74517304633fca48", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6837), "b602ced735fc44f2aabd956b935aaea616", 13.0, -75, 43, "Test Description Project_40", "KL-8", new DateTime(2024, 4, 28, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6837), new DateTime(2024, 4, 20, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6837), "0fa459153a544c6680598e0b2c54cc9b8", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6837), 32, "Project_8", 5.0, new DateTime(2024, 4, 29, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6837), "Payment Detailes For Project_8", 8.0, 1, 224 },
                    { "b859bc8030ed40dc90251c2dfff0aaf32", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6258), "3a5ea2459dcb43348fd86a60195dfd9712", 7.0, -57, 13, "Test Description Project_10", "KL-2", new DateTime(2024, 4, 10, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6258), new DateTime(2024, 4, 8, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6258), "a73a45ededf94841854d83793690602b6", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6258), 8, "Project_2", 5.0, new DateTime(2024, 4, 11, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6258), "Payment Detailes For Project_2", 2.0, 1, 206 },
                    { "cad5110401074ddaa0afd56e8449a1db0", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1624), "dce2568cf3dc4f7abe7b5ba363a486130", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 4, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1624), new DateTime(2024, 4, 4, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1624), "8b76517f14bf4fa69dde98fa90e0d2a90", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1624), 0, "Project_0", 5.0, new DateTime(2024, 4, 5, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1624), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "e8f545990cf946b0a04b40b041d47dab30", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6552), null, 10.0, -66, 28, "Test Description Project_20", "KL-5", new DateTime(2024, 4, 19, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6552), new DateTime(2024, 4, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6552), "596bb28b024d43ff9478522e9ac8ea6130", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6552), 20, "Project_5", 5.0, new DateTime(2024, 4, 20, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6552), "Payment Detailes For Project_20", 5.0, 0, 215 },
                    { "faa50f2f5a7843cf9a15443cc4bc4cae4", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1734), null, 6.0, -54, 8, "Test Description Project_4", "KL-1", new DateTime(2024, 4, 7, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 4, 6, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1734), "ef1bc388564c465895f7141a62fa43584", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1734), 4, "Project_1", 5.0, new DateTime(2024, 4, 8, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1734), "Payment Detailes For Project_2", 1.0, 0, 203 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { "091a9f531bc84239a677c96fe8431d37", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6488), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6489), "7f06316b735a4935b44afc3939946e1f8", "de475d60b78e4c67a563e46f65e281bd25" },
                    { "2df65855c413419c9db3b6c9ec27bee6", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1680), new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1682), "7f06316b735a4935b44afc3939946e1f8", "8b1026aa4eff4ca9ba6e24038c60e39b6" },
                    { "3202f104e48648b989939213898a8f9a", new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6175), new DateTime(2024, 2, 14, 15, 39, 2, 586, DateTimeKind.Local).AddTicks(6176), "7f06316b735a4935b44afc3939946e1f8", "dce2568cf3dc4f7abe7b5ba363a486130" },
                    { "452c575104124e19b82c57595d3d3d17", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6408), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6410), "7f06316b735a4935b44afc3939946e1f8", "00d2c7541c9e407594c8225a32d723d924" },
                    { "47b265a3a7514ee9a833f186cfe8839f", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6787), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6788), "7f06316b735a4935b44afc3939946e1f8", "b602ced735fc44f2aabd956b935aaea616" },
                    { "48dfb5d3cba2420dbdc0f9457c611c06", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6593), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6595), "7f06316b735a4935b44afc3939946e1f8", "497a6694aca14decaa1092455020ac746" },
                    { "6f2ca69d03d44ad58508aa56d95b4a44", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1706), new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1707), "c67bdf35f73e4b5987351ecd8ce05c726", "8a684c7680ad4fd49df9089231783b7c2" },
                    { "94570ef91afc44e5bd0cf752dbe40c93", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6814), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6815), "c67bdf35f73e4b5987351ecd8ce05c726", "27ec8b42d0fa4f4f945590b56417770748" },
                    { "9b75d3aa7bf048a8bb34ba35046918b4", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6617), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6618), "336a182751df44d9a5b94e3d4e3c1e9c4", "4bc28f5a578f4e45bfbfe5c8cb77c16f12" },
                    { "9f6b3c85630347c7a97e5a873de5fe8e", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6726), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6727), "5b8e6e409d6c4673bcddfa84f1e3053f3", "a92145c5a060417e89dd6874d8a6a16535" },
                    { "afc1d4e559334d708b3f1d3fcb82395f", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6162), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6164), "7f06316b735a4935b44afc3939946e1f8", "3a5ea2459dcb43348fd86a60195dfd9712" },
                    { "b4d3c86e1dc94a1ab72e122ce29f5b19", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6339), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6340), "336a182751df44d9a5b94e3d4e3c1e9c4", "76b470a9fded4f96b8b36a999801f9146" },
                    { "be3e589cf44b4745a295be7fe7845c4c", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6528), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6530), "336a182751df44d9a5b94e3d4e3c1e9c4", "11dc09596d77416aaec4b90fd7b0620920" },
                    { "ca16962626b84defb045449b396142fe", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6213), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6214), "5b8e6e409d6c4673bcddfa84f1e3053f3", "d1ed60f559ee4fd89be7360ccbd898506" },
                    { "d18eb430e08d46c88472a1d4f9d0b3bf", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6295), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6296), "7f06316b735a4935b44afc3939946e1f8", "8100f5c6c8aa4599a289f6e8e765afa39" },
                    { "dfa8af8538c9470eaa20466a3ca1617b", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1570), new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1572), "c67bdf35f73e4b5987351ecd8ce05c726", "e401d2ffebad441d99b404b94cc2112a0" },
                    { "e8b44fb49f97459da42a7748c88ddeb6", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6434), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6435), "336a182751df44d9a5b94e3d4e3c1e9c4", "4403d082880b40fcb5a2ab02c01785ae16" },
                    { "f764494b46de4c5f832d875251b827b8", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6700), new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6701), "7f06316b735a4935b44afc3939946e1f8", "bda306cc98a840938f1dfac119a8e46d28" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "LastUpdatedDate", "ProjectId" },
                values: new object[,]
                {
                    { "675dd00b0a9f47949eede66078b217f64", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1749), "8a684c7680ad4fd49df9089231783b7c2", new DateTime(2024, 2, 14, 15, 39, 2, 588, DateTimeKind.Local).AddTicks(1750), "faa50f2f5a7843cf9a15443cc4bc4cae4" },
                    { "7e4d6d0ab2494869b696082fd61037c312", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6380), "76b470a9fded4f96b8b36a999801f9146", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6381), "01d5dcbba33541e7835112ea013c37806" },
                    { "a340d396704e454c938347e172935eef15", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6566), "11dc09596d77416aaec4b90fd7b0620920", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6567), "e8f545990cf946b0a04b40b041d47dab30" },
                    { "a5104c6f283f40e79aa5d4c914075f2521", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6761), "a92145c5a060417e89dd6874d8a6a16535", new DateTime(2024, 2, 14, 15, 39, 2, 589, DateTimeKind.Local).AddTicks(6763), "0271aea1bbe54681b446bfe897e0ad527" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectsId",
                table: "ProjectUser",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CustomerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "2e7dde7cb7864dd2a5a5724320f27b8418");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "69656e1794c74124a87d40a952a3e17d8");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "89ee9f59233249eb8c74517304633fca48");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "b859bc8030ed40dc90251c2dfff0aaf32");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "cad5110401074ddaa0afd56e8449a1db0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5a1abdb385b04c26b8048acbaa51d5821");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6ecbad0f14f94e49bc0bbfd043e119187");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a329142f0ef74ca1a4109d3123cc2bad2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e50b320011e54694badb0bff04f72c555");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "0fa459153a544c6680598e0b2c54cc9b8");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "21681a4ebc5e424492bef876b72d24136");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "8b76517f14bf4fa69dde98fa90e0d2a90");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "a08fa229c6ed49dd9229b1ced57f0ea112");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "a73a45ededf94841854d83793690602b6");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "01d5dcbba33541e7835112ea013c37806");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "0271aea1bbe54681b446bfe897e0ad527");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "e8f545990cf946b0a04b40b041d47dab30");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: "faa50f2f5a7843cf9a15443cc4bc4cae4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "336a182751df44d9a5b94e3d4e3c1e9c4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5b8e6e409d6c4673bcddfa84f1e3053f3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7f06316b735a4935b44afc3939946e1f8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c67bdf35f73e4b5987351ecd8ce05c726");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "1e29b160ddbc434a826dbd5ec382f9bd15");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "596bb28b024d43ff9478522e9ac8ea6130");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "c4f6e80cd2ec458589f0764fc5f4eec921");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: "ef1bc388564c465895f7141a62fa43584");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Completed",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    EmployeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => new { x.EmployeesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3" },
                values: new object[,]
                {
                    { "142340", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5949), "Test Description Client 0", "alexpl_0@gmail.com", "Platanios_Customer_0", "Alexandros_0", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5951), null, "6949277780", null, null },
                    { "142341", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6032), "Test Description Client 1", "alexpl_1@gmail.com", "Platanios_Customer_1", "Alexandros_1", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6034), null, "6949277781", null, null },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6066), "Test Description Client 2", "alexpl_2@gmail.com", "Platanios_Customer_2", "Alexandros_2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6067), null, "6949277782", null, null },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6100), "Test Description Client 3", "alexpl_3@gmail.com", "Platanios_Customer_3", "Alexandros_3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6101), null, "6949277783", null, null },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6165), "Test Description Client 4", "alexpl_4@gmail.com", "Platanios_Customer_4", "Alexandros_4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6166), null, "6949277784", null, null },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6204), "Test Description Client 5", "alexpl_5@gmail.com", "Platanios_Customer_5", "Alexandros_5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6205), null, "6949277785", null, null },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6236), "Test Description Client 6", "alexpl_6@gmail.com", "Platanios_Customer_6", "Alexandros_6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6237), null, "6949277786", null, null },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6266), "Test Description Client 7", "alexpl_7@gmail.com", "Platanios_Customer_7", "Alexandros_7", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6267), null, "6949277787", null, null },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6319), "Test Description Client 8", "alexpl_8@gmail.com", "Platanios_Customer_8", "Alexandros_8", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6320), null, "6949277788", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Hours", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3" },
                values: new object[,]
                {
                    { "1423410", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6332), "Test Description Employee 10", "alexpl_10@gmail.com", "Platanios_Employee_10", 800000008.0, "Alexandros_10", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6333), null, "69492777810", null, null },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5986), "Test Description Employee 2", "alexpl_2@gmail.com", "Platanios_Employee_2", 0.0, "Alexandros_2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5987), null, "6949277782", null, null },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6043), "Test Description Employee 3", "alexpl_3@gmail.com", "Platanios_Employee_3", 11.0, "Alexandros_3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6045), null, "6949277783", null, null },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6075), "Test Description Employee 4", "alexpl_4@gmail.com", "Platanios_Employee_4", 202.0, "Alexandros_4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6077), null, "6949277784", null, null },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6110), "Test Description Employee 5", "alexpl_5@gmail.com", "Platanios_Employee_5", 3003.0, "Alexandros_5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6111), null, "6949277785", null, null },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6179), "Test Description Employee 6", "alexpl_6@gmail.com", "Platanios_Employee_6", 40004.0, "Alexandros_6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6180), null, "6949277786", null, null },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6214), "Test Description Employee 7", "alexpl_7@gmail.com", "Platanios_Employee_7", 500005.0, "Alexandros_7", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6215), null, "6949277787", null, null },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6246), "Test Description Employee 8", "alexpl_8@gmail.com", "Platanios_Employee_8", 6000006.0, "Alexandros_8", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6247), null, "6949277788", null, null },
                    { "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6275), "Test Description Employee 9", "alexpl_9@gmail.com", "Platanios_Employee_9", 70000007.0, "Alexandros_9", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6277), null, "6949277789", null, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "Total", "Vat" },
                values: new object[,]
                {
                    { "1423410", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6347), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6348), "Signature 1423410", 36614, 8.0, 24.0 },
                    { "142342", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3001.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6015), "Signature 142342", 76040, 0.0, 24.0 },
                    { "142343", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6055), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3010.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6056), "Signature 142343", 45166, 1.0, 17.0 },
                    { "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6089), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3100.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6090), "Signature 142344", 49875, 2.0, 24.0 },
                    { "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6154), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6155), "Signature 142345", 31259, 3.0, 17.0 },
                    { "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6193), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6194), "Signature 142346", 55311, 4.0, 24.0 },
                    { "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6226), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6227), "Signature 142347", 89217, 5.0, 17.0 },
                    { "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6256), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6257), "Signature 142348", 67400, 6.0, 24.0 },
                    { "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6286), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10003000.0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6288), "Signature 142349", 48507, 7.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { "1", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5768), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5810), "Draftsmen" },
                    { "2", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5817), "Engineers" },
                    { "3", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5819), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5820), "Project Managers" },
                    { "4", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5822), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5823), "COO" },
                    { "5", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5826), "CTO" },
                    { "6", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5827), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5828), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Bank", "CalculationDaly", "Code", "Completed", "CreatedDate", "CustomerId", "DayCost", "DaysUntilPayment", "DelayInPayment", "Description", "Drawing", "DurationDate", "EstPaymentDate", "InvoiceId", "LastUpdatedDate", "ManHours", "Name", "PaidFee", "PaymentDate", "PaymentDetailes", "PendingPayments", "PlanType", "WorkingDays" },
                values: new object[,]
                {
                    { "25460", "ALPHA", 0, "D-22-160", 0, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), "142347", 5.0, -51, 3, "Test Description Project_0", "KL-0", new DateTime(2024, 4, 2, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), new DateTime(2024, 4, 2, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), 0, "Project_0", 5.0, new DateTime(2024, 4, 3, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6359), "Payment Detailes For Project_0", 0.0, 1, 200 },
                    { "25461", "NBG_IBANK", 1, "D-22-161", 10, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), "142343", 6.0, -54, 8, "Test Description Project_1", "KL-1", new DateTime(2024, 4, 5, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), new DateTime(2024, 4, 4, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), 8, "Project_1", 5.0, new DateTime(2024, 4, 6, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6406), "Payment Detailes For Project_1", 1.0, 0, 203 },
                    { "25462", "ALPHA", 2, "D-22-162", 20, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "142341", 7.0, -57, 13, "Test Description Project_2", "KL-2", new DateTime(2024, 4, 8, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), new DateTime(2024, 4, 6, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "142344", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), 32, "Project_2", 5.0, new DateTime(2024, 4, 9, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6430), "Payment Detailes For Project_2", 2.0, 1, 206 },
                    { "25463", "NBG_IBANK", 3, "D-22-163", 30, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "142347", 8.0, -60, 18, "Test Description Project_3", "KL-3", new DateTime(2024, 4, 11, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), new DateTime(2024, 4, 8, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "142345", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), 72, "Project_3", 5.0, new DateTime(2024, 4, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6447), "Payment Detailes For Project_3", 3.0, 0, 209 },
                    { "25464", "ALPHA", 4, "D-22-164", 40, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), "142341", 9.0, -63, 23, "Test Description Project_4", "KL-4", new DateTime(2024, 4, 14, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), new DateTime(2024, 4, 10, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), 128, "Project_4", 5.0, new DateTime(2024, 4, 15, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6464), "Payment Detailes For Project_4", 4.0, 1, 212 },
                    { "25465", "NBG_IBANK", 1, "D-22-165", 50, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "142343", 10.0, -66, 28, "Test Description Project_5", "KL-5", new DateTime(2024, 4, 17, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), new DateTime(2024, 4, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "142346", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), 200, "Project_5", 5.0, new DateTime(2024, 4, 18, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6479), "Payment Detailes For Project_5", 5.0, 0, 215 },
                    { "25466", "ALPHA", 1, "D-22-166", 60, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), "142343", 11.0, -69, 33, "Test Description Project_6", "KL-6", new DateTime(2024, 4, 20, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), new DateTime(2024, 4, 14, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), null, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), 288, "Project_6", 5.0, new DateTime(2024, 4, 21, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6492), "Payment Detailes For Project_6", 6.0, 1, 218 },
                    { "25467", "NBG_IBANK", 1, "D-22-167", 70, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "142345", 12.0, -72, 38, "Test Description Project_7", "KL-7", new DateTime(2024, 4, 23, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), new DateTime(2024, 4, 16, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "142349", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), 392, "Project_7", 5.0, new DateTime(2024, 4, 24, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6531), "Payment Detailes For Project_7", 7.0, 0, 221 },
                    { "25468", "ALPHA", 1, "D-22-168", 80, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "142345", 13.0, -75, 43, "Test Description Project_8", "KL-8", new DateTime(2024, 4, 26, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), new DateTime(2024, 4, 18, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "142347", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), 512, "Project_8", 5.0, new DateTime(2024, 4, 27, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6545), "Payment Detailes For Project_8", 8.0, 1, 224 },
                    { "25469", "NBG_IBANK", 1, "D-22-169", 90, new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "142341", 14.0, -78, 48, "Test Description Project_9", "KL-9", new DateTime(2024, 4, 29, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), new DateTime(2024, 4, 20, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "142348", new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), 648, "Project_9", 5.0, new DateTime(2024, 4, 30, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(6559), "Payment Detailes For Project_9", 9.0, 0, 227 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_RolesId",
                table: "EmployeeRole",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
