using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Projects_InvoiceId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Invoices");

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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5768), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5819), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5822), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5823) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5825), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5827), new DateTime(2024, 2, 12, 16, 11, 20, 68, DateTimeKind.Local).AddTicks(5828) });

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
                name: "IX_Projects_InvoiceId",
                table: "Projects",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_InvoiceId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142340");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142342");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142344");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142346");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142348");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1423410");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142342");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142343");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142344");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142345");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142346");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142347");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142348");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "142349");

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
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142341");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142343");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142345");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "142347");

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

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_InvoiceId",
                table: "Projects",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectId",
                table: "Invoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
