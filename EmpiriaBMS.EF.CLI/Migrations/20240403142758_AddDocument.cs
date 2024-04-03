using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpiriaBMS.EF.CLI.Migrations
{
    public partial class AddDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Roles_RoleId",
                table: "Issues");

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2126765688, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2043627592, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2039382160, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2018807360, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1765060216, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1466298128, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1461728600, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1387564456, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1374660912, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1304128112, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1072777880, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1025676768, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1004363320, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -821294672, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -766589960, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -669688480, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -13046320, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 48500184, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 55276880, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 761217232, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 853549824, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 858113144, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 903388600, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1014884392, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1249013408, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1338483552, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1476244320, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1514478272, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1735143456, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1786998136, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1922016840, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1961561656, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 159794805 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 221583835 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 222029997 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 310844693 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 423324696 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 481435429 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 523335748 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 604231330 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 667465284 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 689402813 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 693577134 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 804725668 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 980722489 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 989427526 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 995610588 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 2058347776, 997222832 });

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 164385389);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 290350167);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 669499730);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 139389886);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 141863418);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 144940712);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 144996997);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 145438318);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 165748714);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 166806025);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 188641697);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 195394316);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 196765683);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 233393383);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 238070596);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 245985170);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 286584383);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 324109566);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 330135627);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 331994708);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 346958205);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 351105458);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 365873516);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 366107512);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 382780665);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 401097784);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 410989400);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 415458283);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 430225625);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 433650873);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 445716980);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 449122456);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 452435566);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 458648265);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 466067187);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 471993376);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 483098671);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 492471635);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 509588651);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 517164727);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 522007574);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 528237580);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 532196716);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 533136314);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 550574008);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 578870416);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 582464991);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 584123569);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 584706630);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 591979027);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 594261554);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 599209268);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 605633336);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 605909021);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 608313961);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 610892276);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 614331024);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 637433106);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 637469910);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 654931239);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 662048967);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 662244733);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 662862392);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 663241534);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 677620455);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 679146884);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 685108337);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 690155728);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 693129786);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 695450397);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 702662235);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 720071025);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 727891081);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 734332619);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 740163096);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 741951895);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 747712163);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 749463614);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 749827857);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 760100214);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 768938438);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 774325581);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 790216596);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 793944305);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 800430559);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 816769314);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 831310279);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 848354721);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 861383022);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 864035135);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 874809491);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 896791374);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 904233760);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 915688254);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 917369037);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 918859602);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 920132106);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 926371964);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 931332767);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 938458115);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 940218524);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 960896484);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 961832443);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 977582482);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 979904213);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 339226810);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 348259806);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 414022111);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 428785915);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 462665831);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 478869674);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 480495823);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 597598690);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 631486737);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 637049161);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 643162329);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 647500833);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 685942768);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 724124329);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 761469600);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 797299087);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 821570621);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 841051034);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 843479288);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 847734435);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 861757778);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 989853979);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 146696663);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 380678347);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 422248645);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 444653229);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 467307575);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 513310416);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 603505183);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 694633497);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 749276467);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 910211743);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 978781555);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 126063958);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 134473820);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 134805857);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 139053606);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 144509740);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 145800218);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 146690114);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 147698393);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 148782614);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 151236730);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 154936229);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 155437173);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 157564405);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 158145370);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 160447486);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 166441017);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 169239853);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 171674864);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 173141223);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 180004949);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 180824655);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 181115801);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 184525603);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 185217033);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 190831966);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 202648671);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 203939403);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 214816263);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 223455921);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 225696179);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 226732102);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 234424144);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 242267469);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 245134540);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 246959514);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 253158146);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 256396501);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 268707202);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 274488782);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 278137378);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 282594345);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 282744356);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 283092996);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 289823663);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 295176940);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 295442006);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 297498086);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 299698831);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 302397690);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 305459711);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 309858500);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 331535684);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 334066236);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 342351434);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 345017295);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 351982007);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 354691895);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 358210545);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 358761038);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 359153437);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 359446938);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 360587055);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 368150147);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 369934560);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 371241452);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 373407703);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 381845923);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 383553101);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 384112042);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 388643955);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 392070281);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 395811635);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 396118172);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 396217945);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 404634333);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 407733156);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 409105923);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 411806401);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 411963670);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 412610174);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 413925770);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 417726192);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 424616608);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 427188878);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 427984797);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 431625352);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 431741932);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 439919129);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 442150090);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 447600728);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 450572624);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 450865314);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 455495418);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 455789061);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 456797368);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 461832385);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 462333272);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 470497093);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 470954226);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 472418252);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 475227446);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 475583646);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 481334510);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 488092338);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 491893251);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 492170232);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 498955767);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 499524573);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 503761209);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 506022457);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 506852522);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 517156757);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 519337672);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 521958035);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 524386225);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 525605719);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 528568138);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 532152993);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 532749109);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 537219141);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 537310341);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 537501606);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 540688801);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 541140804);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 548242798);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 550123250);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 553375523);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 557376595);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 561666140);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 562670575);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 568788948);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 569890174);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 572923330);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 573704288);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 573913337);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 581211026);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 582747204);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 586901122);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 590167047);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 591756576);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 595457837);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 600446950);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 609267289);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 613470609);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 613597598);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 618064032);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 623142008);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 626240035);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 629419542);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 633021231);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 634820096);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 646288114);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 647524075);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 659436530);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 661982021);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 668791091);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 671766057);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 677259498);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 682314890);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 689277252);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 690083203);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 697262262);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 703605342);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 704402649);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 706651076);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 712626673);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 719538118);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 721191519);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 723619736);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 725464947);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 726043906);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 726716596);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 735137275);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 745570230);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 746808719);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 748330282);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 748810018);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 751814570);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 753217552);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 764176679);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 768165449);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 775691139);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 776786555);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 776971727);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 785606972);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 802893246);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 805066220);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 805082566);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 806352171);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 816405029);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 821638235);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 826282664);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 827490006);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 844215306);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 846366107);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 848640872);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 848772692);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 852772967);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 853186500);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 853941054);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 854672914);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 857022856);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 857633717);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 864372855);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 866272710);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 868726405);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 871030929);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 871978983);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 878843610);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 880338149);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 883144123);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 887930821);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 890225599);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 894269875);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 895388749);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 896664005);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 898531413);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 902137372);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 907582130);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 911804476);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 914745421);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 924068678);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 924815749);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 931457317);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 933137808);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 940829396);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 942637849);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 943084058);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 954651892);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 959629463);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 961225835);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 962608977);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 968602713);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 970773276);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 972507514);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 972720869);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 991428229);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 997987218);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 479578946, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 164644045 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 412283420, 290102901 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 290102901 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 710856637, 290102901 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 290102901 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 210009642, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 271958213, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 535075931, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 876989901, 391103299 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 710856637, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 395911868 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 479451032 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 479451032 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 479451032 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 130091889, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 142482156, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 210009642, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 357392399, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 399056263, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 482303752, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 535075931, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 674379550, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 698742277, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 705377858, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 710856637, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 877357391, 524835668 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 142482156, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 210009642, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 249695161, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 271958213, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 357392399, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 399056263, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 479578946, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 482303752, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 535075931, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 674379550, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 698742277, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 710856637, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 859859026, 532804602 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 271958213, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 377058179, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 479578946, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 502867731, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 604322297, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 674379550, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 710856637, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854265727, 692744033 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 822198159 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 837327415, 871737531 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 159794805 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 221583835 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 222029997 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 310844693 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 532804602, 310844693 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 290102901, 396069851 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 423324696 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 481435429 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 523335748 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 479451032, 530043390 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 479451032, 590012631 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 604231330 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 667465284 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 290102901, 667465284 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 391103299, 667465284 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 524835668, 667465284 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 692744033, 667465284 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 689402813 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 693577134 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 804725668 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 391103299, 804725668 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 395911868, 825284728 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 479451032, 835483227 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 980722489 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 989427526 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 995610588 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 391103299, 995610588 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 164644045, 997222832 });

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2126765688);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2043627592);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2039382160);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2018807360);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1765060216);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1466298128);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1461728600);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1387564456);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1374660912);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1304128112);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1072777880);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1025676768);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1004363320);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -821294672);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -766589960);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -669688480);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -13046320);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 48500184);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 55276880);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 761217232);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 853549824);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 858113144);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 903388600);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1014884392);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1249013408);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1338483552);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1476244320);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1514478272);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1735143456);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1786998136);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1922016840);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1961561656);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2058347776);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 2091716744);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 264194405);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 657063491);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 834534160);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 207022497);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 498609019);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 716360954);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 722064785);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 724276678);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 775558853);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 852909449);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 130091889);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 142482156);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 210009642);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 249695161);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 271958213);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 357392399);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 377058179);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 399056263);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 412283420);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 479578946);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 482303752);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 502867731);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 535075931);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 604322297);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 674379550);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 698742277);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 705377858);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 710856637);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 837327415);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 854265727);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 859859026);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 876989901);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 877357391);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 290102901);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 395911868);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 479451032);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 822198159);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 871737531);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 159794805);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 221583835);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222029997);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 310844693);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 396069851);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 423324696);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 481435429);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 523335748);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 530043390);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 590012631);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 604231330);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 689402813);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 693577134);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 825284728);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 835483227);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 980722489);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 989427526);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 997222832);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 184189092);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 331354428);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 390116240);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 409266178);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 482509020);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 501166454);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 628937181);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 651723815);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 655146632);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 687142022);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 717305095);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 727931962);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 731022631);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 764445405);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 867770896);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 885615685);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 951621683);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 198329397);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 360899757);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 547254174);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 564441100);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 658695706);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 667712873);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 682107086);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 694095980);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 749387009);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 882693604);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 887658868);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 905642845);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 164644045);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 188084384);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 423946154);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 751518333);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 797155677);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 961011244);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 391103299);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 667465284);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 804725668);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 995610588);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 524835668);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 692744033);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 532804602);

            migrationBuilder.DropColumn(
                name: "About",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Issues",
                newName: "DisplayedRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_RoleId",
                table: "Issues",
                newName: "IX_Issues_DisplayedRoleId");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DisciplineTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 151973675, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2229), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2230), "Burglar Alarm" },
                    { 229452996, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2303), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2305), "TenderDocument" },
                    { 231636455, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2343), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2345), "Project Manager Hours" },
                    { 265941510, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2124), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2125), "Potable Water" },
                    { 298942904, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2291), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2292), "Outsource" },
                    { 305229622, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2318), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2319), "Construction Supervision" },
                    { 321322402, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2150), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2151), "Fire Detection" },
                    { 383201487, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2177), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2178), "Elevators" },
                    { 385441638, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2164), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2165), "Fire Suppression" },
                    { 427368052, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2111), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2112), "Sewage" },
                    { 434918733, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2216), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2217), "Structured Cabling" },
                    { 548666294, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2137), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2138), "Drainage" },
                    { 577009269, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2090), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2091), "HVAC" },
                    { 699259899, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2202), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2203), "Power Distribution" },
                    { 727815759, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2241), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2242), "CCTV" },
                    { 761432802, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2266), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2267), "Photovoltaics" },
                    { 791021286, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2330), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2331), "DWG Admin/Clearing" },
                    { 829677651, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2254), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2255), "BMS" },
                    { 885071061, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2279), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2280), "Energy Efficiency" },
                    { 949717299, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2189), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2190), "Natural Gas" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 268459121, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2848), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2849), "Documents" },
                    { 621147985, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2882), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2883), "Drawings" },
                    { 905688991, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2869), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2870), "Calculations" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 165955446, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4403), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4404), "Communications" },
                    { 239928411, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4464), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4465), "Administration" },
                    { 400712125, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4423), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4424), "Printing" },
                    { 538780288, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4491), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4492), "Hours To Be Erased" },
                    { 558966587, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4437), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4438), "On-Site" },
                    { 828779598, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4451), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4452), "Meetings" },
                    { 845528590, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4478), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4479), "Soft Copy" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 176097931, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9137), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9139), "Display Projects Code", 13 },
                    { 184199148, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8866), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8867), "See Dashboard Layout", 1 },
                    { 207193490, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8972), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8973), "Dashboard Edit My Hours", 2 },
                    { 276735076, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9165), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9167), "Dashboard Edit Deliverable", 15 },
                    { 279505313, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9005), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9006), "Dashboard Assign Engineer", 4 },
                    { 286095180, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9243), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9244), "See All Projects Missed DeadLine KPI", 20 },
                    { 287376144, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9079), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9080), "See All Disciplines", 9 },
                    { 365719928, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9257), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9258), "See Employee Turnover KPI", 21 },
                    { 382237209, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(8991), "Dashboard Assign Designer", 3 },
                    { 382582123, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9109), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9110), "See All Projects", 11 },
                    { 416581060, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9123), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9125), "Edit Project On Dashboard", 12 },
                    { 445875851, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9019), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9020), "Dashboard Assign Project Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 500430058, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9285), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9286), "See Active Delayed Project Types Counter KPI", 23 },
                    { 568362095, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9215), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9216), "See Hours Per Role KPI", 18 },
                    { 576092191, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9094), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9095), "See All Drawings", 10 },
                    { 593781710, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9065), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9066), "Dashboard See My Hours", 8 },
                    { 676506509, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9153), "Dashboard Edit Discipline", 14 },
                    { 700824785, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9035), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9037), "Dashboard Add Project", 6 },
                    { 703873135, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9050), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9051), "See Admin Layout", 7 },
                    { 770998996, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9229), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9230), "See Active Delayed Projects KPI", 19 },
                    { 788963579, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9271), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9272), "See My Projects Missed DeadLine KPI", 22 },
                    { 854210932, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9180), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9181), "Dashboard Edit Other", 16 },
                    { 937022600, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9194), new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9195), "Dashboard See KPIS", 17 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 328788640, true, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1510), "Infrastructure Description", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1511), "Infrastructure" },
                    { 346503376, true, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1492), "Buildings Description", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1493), "Buildings" },
                    { 578630126, true, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1525), "Energy Description", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1527), "Energy" },
                    { 682049824, false, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1554), "Production Management Description", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1555), "Production Management" },
                    { 735209553, true, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1540), "Consulting Description", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1541), "Consulting" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 384005857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9436), false, false, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9437), "Admin", null },
                    { 531140448, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9407), false, false, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9408), "Guest", null },
                    { 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9300), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9302), "CEO", null },
                    { 651976103, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9421), false, false, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9422), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1319), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1320), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1447), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1448), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(983), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(985), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(789), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(790), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1363), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1364), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1140), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1141), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1098), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1099), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null },
                    { 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1186), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1188), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(923), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(924), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 608823485, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(609), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(610), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(836), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(837), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(743), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(744), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 650236807, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1614), "Admin", "Alexandros", "Platanios", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1615), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com", null },
                    { 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(878), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(880), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 729039359, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(654), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(655), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1231), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1233), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 783169759, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(531), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(533), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1275), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1276), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 821016946, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(697), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(699), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1405), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1406), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1054), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1055), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 155561801, "ogiannoglou@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1289), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1291), 790206202 },
                    { 169099735, "vpax@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(759), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(760), 648344074 },
                    { 177377794, "kkotsoni@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(998), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(999), 271869663 },
                    { 262401343, "xmanarolis@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(807), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(808), 281876897 },
                    { 281876410, "vtza@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1069), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1071), 883028983 },
                    { 329026571, "vchontos@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1377), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1379), 356120023 },
                    { 346323248, "pfokianou@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1247), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1248), 770084161 },
                    { 375608351, "embiria@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(554), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(555), 783169759 },
                    { 380736071, "panperivollari@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1419), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1421), 848034177 },
                    { 396677488, "blekou@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1334), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1335), 138517350 },
                    { 481496331, "kmargeti@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1158), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1159), 363478825 },
                    { 585307796, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(712), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(714), 821016946 },
                    { 591069402, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(669), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(670), 729039359 },
                    { 592547697, "ntriantafyllou@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1461), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1462), 220858511 },
                    { 636996253, "haris@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1201), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1202), 549298984 },
                    { 656003193, "ngal@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(940), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(941), 604317923 },
                    { 730958540, "chkovras@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(893), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(894), 660865722 },
                    { 771708511, "empiriasoft@empiriasoftplat.onmicrosoft.com", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1630), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1631), 650236807 },
                    { 833003655, "gdoug@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(626), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(627), 608823485 },
                    { 863458992, "sparisis@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(851), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(852), 640869632 },
                    { 955377490, "agretos@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1112), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1113), 480985555 },
                    { 993973775, "akonstantinidou@embiria.gr", new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(574), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(575), 783169759 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "StartDate", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 163199002, false, 1, "D-22-169", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2023, 9, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_14", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_9", 648344074, new DateTime(2023, 2, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 578630126, 0f },
                    { 290458482, true, 1, "D-22-168", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2023, 10, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_18", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_8", 549298984, new DateTime(2023, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 328788640, 0f },
                    { 404804570, true, 2, "D-22-164", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 2, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_2", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_4", 271869663, new DateTime(2023, 12, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 328788640, 0f },
                    { 412747066, false, 1, "D-22-161", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 5, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_6", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_1", 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 346503376, 0f },
                    { 427390014, false, 1, "D-22-167", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2023, 11, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_15", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_7", 271869663, new DateTime(2023, 6, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 346503376, 0f },
                    { 466045658, false, 3, "D-22-165", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 1, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_3", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_5", 549298984, new DateTime(2023, 10, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 578630126, 0f },
                    { 535588583, true, 2, "D-22-162", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 8, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_8", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_2", 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 328788640, 0f },
                    { 564589086, true, 4, "D-22-166", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2023, 12, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_8", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_6", 648344074, new DateTime(2023, 8, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 735209553, 0f },
                    { 702103121, false, 3, "D-22-163", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2025, 1, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_15", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_3", 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 578630126, 0f },
                    { 747388350, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 7, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_PM", 0f, 1500L, 12L, null, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_PM", null, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 682049824, 0f },
                    { 763659356, false, 1, "D-22-163", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2024, 3, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_2", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_Missed_DeadLine_3", 648344074, new DateTime(2024, 2, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 346503376, 0f },
                    { 916539812, true, 4, "D-22-164", 0f, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), new DateTime(2025, 8, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Test Description Project_8", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), "Project_4", 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 450, DateTimeKind.Local).AddTicks(1685), null, 735209553, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 287376144, 384005857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(397), 152348788, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(398) },
                    { 382582123, 384005857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(430), 1107815009, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(431) },
                    { 576092191, 384005857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(412), -1398735445, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(414) },
                    { 703873135, 384005857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(383), 1571698845, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(384) },
                    { 184199148, 531140448, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(354), 1550970266, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(356) },
                    { 176097931, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(243), -1165782829, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(244) },
                    { 184199148, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(117), -2052700780, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(118) },
                    { 207193490, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(131), 2140116584, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(132) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 279505313, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(158), 216964657, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(159) },
                    { 286095180, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(312), -499842656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(314) },
                    { 287376144, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(201), -1796551262, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(203) },
                    { 365719928, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(326), -1863523543, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(328) },
                    { 382237209, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(144), 1335385269, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(146) },
                    { 382582123, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(229), -977840608, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(231) },
                    { 416581060, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(257), 222050687, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(258) },
                    { 445875851, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(173), 372631523, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(175) },
                    { 500430058, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(340), -582977438, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(342) },
                    { 568362095, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(285), -1830603352, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(286) },
                    { 576092191, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(215), 316339759, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(217) },
                    { 700824785, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(187), 1802595600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(189) },
                    { 770998996, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(298), -1707082118, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(300) },
                    { 937022600, 650911188, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(271), 286840139, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(272) },
                    { 184199148, 651976103, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(369), -11064550, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(370) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9319), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9320), "COO", 650911188 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 384005857, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1657), 210962621, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1658) },
                    { 650911188, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(969), 514362787, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(970) },
                    { 384005857, 650236807, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1643), 124896531, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1644) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2083657472, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2778), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2779), 290458482, 321322402, null },
                    { -2011520240, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2684), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2685), 564589086, 761432802, null },
                    { -1819396000, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2659), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2660), 466045658, 298942904, null },
                    { -1699909864, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2539), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2541), 916539812, 829677651, null },
                    { -1659309952, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2816), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2817), 163199002, 383201487, null },
                    { -1653977944, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2399), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2400), 412747066, 829677651, null },
                    { -1625851672, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2553), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2554), 763659356, 548666294, null },
                    { -1514757176, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2592), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2593), 404804570, 949717299, null },
                    { -1421860816, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2713), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2714), 427390014, 229452996, null },
                    { -1409396880, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2831), 0f, 500L, 0L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2833), 747388350, 231636455, null },
                    { -1331637752, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2485), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2486), 702103121, 577009269, null },
                    { -962818952, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2472), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2473), 702103121, 385441638, null },
                    { -775858864, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2578), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2580), 763659356, 298942904, null },
                    { -633240176, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2765), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2766), 290458482, 949717299, null },
                    { -543353784, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2498), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2499), 702103121, 699259899, null },
                    { -5301200, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2739), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2740), 427390014, 383201487, null },
                    { 32266600, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2565), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2567), 763659356, 949717299, null },
                    { 305281784, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2375), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2376), 412747066, 298942904, null },
                    { 663178888, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2526), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2527), 916539812, 305229622, null },
                    { 804313112, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2620), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2621), 404804570, 385441638, null },
                    { 863756784, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2804), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2805), 163199002, 699259899, null },
                    { 1003449224, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2442), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2443), 535588583, 265941510, null },
                    { 1009618680, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2458), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2459), 535588583, 298942904, null },
                    { 1040116512, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2604), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2605), 404804570, 321322402, null },
                    { 1042653064, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2752), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2753), 290458482, 265941510, null },
                    { 1112010912, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2671), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2673), 564589086, 727815759, null },
                    { 1271275656, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2646), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2647), 466045658, 151973675, null },
                    { 1347717952, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2513), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2514), 916539812, 151973675, null },
                    { 1363207760, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2791), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2792), 163199002, 385441638, null },
                    { 1485083712, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2697), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2698), 564589086, 577009269, null },
                    { 1560873936, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2633), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2634), 466045658, 383201487, null },
                    { 1581735624, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2412), 0f, 416L, 52L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2413), 412747066, 949717299, null },
                    { 1647354272, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2426), 0f, 400L, 50L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2427), 535588583, 383201487, null },
                    { 1738146864, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2726), 0f, 408L, 51L, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2728), 427390014, 949717299, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 141917859, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1722), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1724), 3010.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1723), "Signature 142342", 77952, 412747066, 1.0, 17.0 },
                    { 171713976, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1765), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1768), 3100.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1767), "Signature 142344", 34952, 535588583, 2.0, 24.0 },
                    { 288397280, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1800), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1802), 4000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1801), "Signature 1423412", 43967, 702103121, 3.0, 17.0 },
                    { 352105424, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2039), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2041), 1003000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2040), "Signature 1423430", 64062, 290458482, 6.0, 24.0 },
                    { 444767366, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2008), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2011), 103000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2010), "Signature 1423430", 26659, 427390014, 5.0, 17.0 },
                    { 489176939, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1949), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1951), 4000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1950), "Signature 142349", 74896, 466045658, 3.0, 17.0 },
                    { 516802221, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1887), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1890), 3010.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1889), "Signature 142344", 53829, 763659356, 1.0, 17.0 },
                    { 521536590, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1921), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1923), 3100.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1922), "Signature 1423410", 58525, 404804570, 2.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 751455039, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1830), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1832), 13000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1831), "Signature 1423416", 68491, 916539812, 4.0, 24.0 },
                    { 781846729, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2068), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2070), 10003000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2069), "Signature 1423421", 51753, 163199002, 7.0, 17.0 },
                    { 843677771, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1978), new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1981), 13000.0, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1980), "Signature 1423416", 26561, 564589086, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 184199148, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9736), 332166466, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9738) },
                    { 207193490, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9750), -386446603, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9752) },
                    { 279505313, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9779), 390141082, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9780) },
                    { 287376144, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9834), 11804270, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9836) },
                    { 382237209, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9765), 1101746930, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9766) },
                    { 382582123, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9863), -1093255861, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9864) },
                    { 445875851, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9793), -409260599, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9794) },
                    { 576092191, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9848), 1779389649, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9849) },
                    { 593781710, 510040592, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9820), -1042635563, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9822) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9334), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9335), "CTO", 510040592 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 510040592, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1026), 171370660, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1027) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2083657472, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3859), 195311222, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3861) },
                    { -2083657472, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3898), 263243643, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3900) },
                    { -2083657472, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3768), 494562652, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3769) },
                    { -2083657472, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3716), 588353766, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3717) },
                    { -2083657472, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3872), 415627811, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3873) },
                    { -2083657472, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3808), 445073407, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3809) },
                    { -2083657472, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3794), 229353378, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3795) },
                    { -2083657472, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3821), 505630856, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3822) },
                    { -2083657472, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3755), 876366118, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3756) },
                    { -2083657472, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3729), 691689568, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3730) },
                    { -2083657472, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3703), 486875802, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3704) },
                    { -2083657472, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3742), 254252850, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3743) },
                    { -2083657472, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3833), 634798464, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3835) },
                    { -2083657472, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3847), 271487351, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3848) },
                    { -2083657472, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3885), 716908335, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3886) },
                    { -2083657472, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3781), 512659694, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3783) },
                    { -2011520240, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2385), 284078901, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2386) },
                    { -2011520240, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2428), 546757886, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2429) },
                    { -2011520240, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2294), 238376491, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2295) },
                    { -2011520240, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2241), 806407881, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2242) },
                    { -2011520240, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2402), 735580020, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2403) },
                    { -2011520240, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2333), 887487382, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2334) },
                    { -2011520240, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2320), 787279105, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2321) },
                    { -2011520240, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2346), 250586766, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2347) },
                    { -2011520240, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2281), 305883669, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2282) },
                    { -2011520240, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2255), 812901513, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2256) },
                    { -2011520240, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2228), 231809228, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2229) },
                    { -2011520240, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2268), 823259509, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2269) },
                    { -2011520240, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2359), 536103237, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2360) },
                    { -2011520240, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2372), 718075300, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2373) },
                    { -2011520240, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2415), 468096373, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2416) },
                    { -2011520240, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2307), 828046093, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2308) },
                    { -1819396000, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1964), 986727619, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1965) },
                    { -1819396000, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2005), 385694310, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2006) },
                    { -1819396000, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1872), 266983487, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1873) },
                    { -1819396000, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1819), 432169295, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1820) },
                    { -1819396000, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1977), 465067543, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1978) },
                    { -1819396000, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1911), 905115080, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1913) },
                    { -1819396000, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1898), 942749124, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1899) },
                    { -1819396000, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1925), 190735299, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1926) },
                    { -1819396000, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1858), 863166207, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1859) },
                    { -1819396000, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1832), 901332393, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1833) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1819396000, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1805), 778615886, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1806) },
                    { -1819396000, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1845), 758602109, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1846) },
                    { -1819396000, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1938), 143225484, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1939) },
                    { -1819396000, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1950), 382406211, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1952) },
                    { -1819396000, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1992), 745164319, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1993) },
                    { -1819396000, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1885), 753865621, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1886) },
                    { -1699909864, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(56), 745523200, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(57) },
                    { -1699909864, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(95), 223169750, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(96) },
                    { -1699909864, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9965), 170009777, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9966) },
                    { -1699909864, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9912), 717829162, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9913) },
                    { -1699909864, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(69), 250342317, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(70) },
                    { -1699909864, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4), 453438784, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(5) },
                    { -1699909864, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9991), 859925651, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9992) },
                    { -1699909864, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(17), 943935896, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(18) },
                    { -1699909864, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9952), 481680548, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9953) },
                    { -1699909864, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9925), 893538285, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9926) },
                    { -1699909864, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9899), 682487108, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9900) },
                    { -1699909864, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9938), 209292363, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9939) },
                    { -1699909864, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(30), 881307446, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(31) },
                    { -1699909864, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(43), 721582180, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(44) },
                    { -1699909864, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(82), 129963266, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(83) },
                    { -1699909864, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9978), 169975634, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9979) },
                    { -1659309952, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4503), 713406521, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4505) },
                    { -1659309952, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4542), 860436363, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4544) },
                    { -1659309952, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4409), 720839513, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4410) },
                    { -1659309952, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4357), 226882303, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4358) },
                    { -1659309952, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4517), 926244454, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4518) },
                    { -1659309952, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4451), 522756484, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4452) },
                    { -1659309952, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4435), 957757107, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4437) },
                    { -1659309952, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4464), 888683092, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4465) },
                    { -1659309952, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4396), 934210845, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4397) },
                    { -1659309952, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4370), 965366275, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4371) },
                    { -1659309952, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4337), 581866281, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4339) },
                    { -1659309952, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4383), 990174178, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4384) },
                    { -1659309952, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4477), 271336044, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4479) },
                    { -1659309952, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4490), 234465723, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4492) },
                    { -1659309952, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4530), 836690961, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4531) },
                    { -1659309952, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4422), 264815878, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4423) },
                    { -1653977944, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7938), 725406255, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7939) },
                    { -1653977944, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7977), 282271598, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7978) },
                    { -1653977944, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7843), 341975588, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7844) },
                    { -1653977944, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7791), 850294799, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7792) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1653977944, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7950), 543836876, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7952) },
                    { -1653977944, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7884), 562780375, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7886) },
                    { -1653977944, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7871), 381776962, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7872) },
                    { -1653977944, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7898), 516012419, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7899) },
                    { -1653977944, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7830), 132066228, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7831) },
                    { -1653977944, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7804), 669721115, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7805) },
                    { -1653977944, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7777), 782967688, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7778) },
                    { -1653977944, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7817), 884576075, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7818) },
                    { -1653977944, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7911), 452359158, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7912) },
                    { -1653977944, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7925), 816259779, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7926) },
                    { -1653977944, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7964), 571337854, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7965) },
                    { -1653977944, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7856), 422604015, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7857) },
                    { -1625851672, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(269), 418029548, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(270) },
                    { -1625851672, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(308), 606906222, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(309) },
                    { -1625851672, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(177), 468836137, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(178) },
                    { -1625851672, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(122), 771862520, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(123) },
                    { -1625851672, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(282), 488905465, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(283) },
                    { -1625851672, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(216), 989719302, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(217) },
                    { -1625851672, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(203), 519018453, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(204) },
                    { -1625851672, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(230), 322893274, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(231) },
                    { -1625851672, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(164), 984985621, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(165) },
                    { -1625851672, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(135), 289007517, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(136) },
                    { -1625851672, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(109), 222515514, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(110) },
                    { -1625851672, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(151), 947332722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(152) },
                    { -1625851672, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(243), 438115848, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(244) },
                    { -1625851672, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(256), 495666823, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(257) },
                    { -1625851672, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(295), 301628279, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(296) },
                    { -1625851672, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(190), 670592554, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(191) },
                    { -1514757176, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(903), 205468527, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(905) },
                    { -1514757176, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(942), 971232137, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(943) },
                    { -1514757176, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(812), 734535474, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(813) },
                    { -1514757176, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(760), 501436692, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(761) },
                    { -1514757176, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(916), 374305495, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(917) },
                    { -1514757176, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(851), 481763489, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(853) },
                    { -1514757176, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(838), 500919146, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(840) },
                    { -1514757176, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(865), 473324066, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(866) },
                    { -1514757176, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(799), 936273663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(800) },
                    { -1514757176, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(773), 814241004, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(774) },
                    { -1514757176, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(747), 878039809, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(748) },
                    { -1514757176, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(786), 553728266, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(787) },
                    { -1514757176, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(877), 691215460, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(879) },
                    { -1514757176, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(890), 326277627, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(892) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1514757176, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(929), 862670395, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(930) },
                    { -1514757176, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(825), 524671072, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(826) },
                    { -1421860816, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2808), 303696061, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2809) },
                    { -1421860816, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2847), 578765590, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2848) },
                    { -1421860816, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2714), 245704391, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2715) },
                    { -1421860816, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2662), 953962691, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2664) },
                    { -1421860816, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2821), 794246773, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2822) },
                    { -1421860816, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2753), 190446794, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2754) },
                    { -1421860816, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2740), 734932289, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2741) },
                    { -1421860816, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2766), 437233562, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2767) },
                    { -1421860816, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2701), 916125072, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2702) },
                    { -1421860816, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2675), 126678346, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2677) },
                    { -1421860816, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2649), 571943084, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2651) },
                    { -1421860816, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2688), 717198043, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2689) },
                    { -1421860816, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2779), 247795010, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2780) },
                    { -1421860816, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2792), 226611608, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2793) },
                    { -1421860816, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2834), 301566462, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2835) },
                    { -1421860816, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2727), 697700809, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2728) },
                    { -1331637752, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9210), 244073135, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9212) },
                    { -1331637752, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9250), 442393021, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9251) },
                    { -1331637752, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9118), 565289128, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9119) },
                    { -1331637752, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9066), 316002733, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9068) },
                    { -1331637752, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9223), 676777520, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9225) },
                    { -1331637752, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9158), 414165962, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9159) },
                    { -1331637752, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9145), 231811200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9146) },
                    { -1331637752, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9171), 594414307, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9172) },
                    { -1331637752, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9105), 718337375, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9107) },
                    { -1331637752, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9080), 994781015, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9081) },
                    { -1331637752, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9053), 186718301, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9055) },
                    { -1331637752, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9093), 662391047, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9094) },
                    { -1331637752, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9184), 363253864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9185) },
                    { -1331637752, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9197), 356605960, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9198) },
                    { -1331637752, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9237), 746723086, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9238) },
                    { -1331637752, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9132), 830977837, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9133) },
                    { -962818952, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8998), 530535482, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8999) },
                    { -962818952, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9040), 265950004, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9041) },
                    { -962818952, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8906), 680410795, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8908) },
                    { -962818952, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8854), 859680583, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8855) },
                    { -962818952, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9011), 981641365, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9012) },
                    { -962818952, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8946), 701558451, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8947) },
                    { -962818952, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8933), 132556794, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8934) },
                    { -962818952, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8959), 726035639, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8960) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -962818952, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8893), 588767579, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8894) },
                    { -962818952, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8867), 848997448, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8868) },
                    { -962818952, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8840), 543760578, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8841) },
                    { -962818952, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8880), 361497049, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8881) },
                    { -962818952, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8972), 533093779, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8974) },
                    { -962818952, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8985), 512035952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8987) },
                    { -962818952, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9027), 916555971, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9028) },
                    { -962818952, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8920), 871396759, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8921) },
                    { -775858864, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(695), 929050216, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(696) },
                    { -775858864, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(733), 662196639, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(735) },
                    { -775858864, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(602), 352854605, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(603) },
                    { -775858864, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(546), 632491558, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(548) },
                    { -775858864, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(708), 842892332, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(709) },
                    { -775858864, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(642), 198007563, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(643) },
                    { -775858864, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(628), 567567683, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(630) },
                    { -775858864, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(655), 984178595, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(656) },
                    { -775858864, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(589), 805650934, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(590) },
                    { -775858864, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(563), 998089662, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(564) },
                    { -775858864, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(534), 738291308, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(535) },
                    { -775858864, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(576), 181033973, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(577) },
                    { -775858864, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(668), 699328988, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(669) },
                    { -775858864, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(682), 927243979, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(683) },
                    { -775858864, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(721), 988785300, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(722) },
                    { -775858864, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(615), 902228112, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(617) },
                    { -633240176, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3651), 418491665, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3652) },
                    { -633240176, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3690), 331523803, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3691) },
                    { -633240176, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3556), 722294712, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3557) },
                    { -633240176, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3504), 670725891, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3506) },
                    { -633240176, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3664), 222497656, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3665) },
                    { -633240176, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3595), 689553557, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3596) },
                    { -633240176, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3582), 933573045, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3583) },
                    { -633240176, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3608), 267355946, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3609) },
                    { -633240176, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3543), 170689313, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3544) },
                    { -633240176, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3517), 416903822, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3518) },
                    { -633240176, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3491), 816259029, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3493) },
                    { -633240176, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3530), 309374217, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3531) },
                    { -633240176, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3625), 390318738, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3626) },
                    { -633240176, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3638), 854779815, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3639) },
                    { -633240176, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3677), 525073810, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3678) },
                    { -633240176, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3569), 712663287, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3570) },
                    { -543353784, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9423), 510890304, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9425) },
                    { -543353784, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9462), 791853177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9464) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -543353784, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9333), 413016040, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9334) },
                    { -543353784, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9278), 320948244, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9279) },
                    { -543353784, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9437), 797779238, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9438) },
                    { -543353784, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9372), 734095521, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9373) },
                    { -543353784, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9359), 886874628, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9361) },
                    { -543353784, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9385), 939899122, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9386) },
                    { -543353784, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9317), 578206704, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9318) },
                    { -543353784, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9291), 382848282, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9292) },
                    { -543353784, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9264), 328183145, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9265) },
                    { -543353784, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9304), 234299355, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9305) },
                    { -543353784, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9398), 313858872, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9399) },
                    { -543353784, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9411), 408559349, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9412) },
                    { -543353784, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9450), 657213890, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9451) },
                    { -543353784, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9346), 903146263, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9348) },
                    { -5301200, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3229), 304039551, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3230) },
                    { -5301200, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3268), 741416163, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3269) },
                    { -5301200, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3135), 599836398, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3136) },
                    { -5301200, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3083), 579403652, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3084) },
                    { -5301200, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3242), 581092437, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3243) },
                    { -5301200, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3174), 130322970, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3175) },
                    { -5301200, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3161), 408725079, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3162) },
                    { -5301200, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3187), 412036484, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3189) },
                    { -5301200, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3122), 312557854, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3123) },
                    { -5301200, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3096), 418261695, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3097) },
                    { -5301200, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3070), 408782284, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3071) },
                    { -5301200, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3109), 914808661, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3110) },
                    { -5301200, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3200), 295846950, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3201) },
                    { -5301200, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3216), 212708319, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3217) },
                    { -5301200, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3255), 706507320, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3256) },
                    { -5301200, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3148), 446649717, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3149) },
                    { 32266600, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(480), 872009974, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(482) },
                    { 32266600, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(520), 300885813, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(521) },
                    { 32266600, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(387), 157192002, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(388) },
                    { 32266600, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(335), 440010576, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(336) },
                    { 32266600, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(494), 441509582, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(495) },
                    { 32266600, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(427), 631578658, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(429) },
                    { 32266600, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(414), 971856444, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(415) },
                    { 32266600, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(441), 856190234, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(442) },
                    { 32266600, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(374), 161626760, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(375) },
                    { 32266600, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(348), 936645732, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(349) },
                    { 32266600, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(322), 947321531, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(323) },
                    { 32266600, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(361), 926804448, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(362) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 32266600, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(454), 936137246, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(455) },
                    { 32266600, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(467), 313729601, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(468) },
                    { 32266600, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(507), 635694592, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(508) },
                    { 32266600, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(400), 607526270, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(401) },
                    { 305281784, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7723), 433815288, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7724) },
                    { 305281784, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7763), 959548361, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7764) },
                    { 305281784, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7630), 318379916, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7631) },
                    { 305281784, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7575), 934219780, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7577) },
                    { 305281784, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7736), 248606237, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7738) },
                    { 305281784, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7669), 949012201, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7670) },
                    { 305281784, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7656), 933391604, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7657) },
                    { 305281784, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7683), 768079046, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7685) },
                    { 305281784, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7616), 582044815, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7617) },
                    { 305281784, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7589), 723452595, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7590) },
                    { 305281784, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7556), 807025984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7557) },
                    { 305281784, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7602), 883742164, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7603) },
                    { 305281784, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7697), 576807672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7698) },
                    { 305281784, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7710), 862278829, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7711) },
                    { 305281784, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7750), 493951871, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7751) },
                    { 305281784, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7643), 376839902, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7644) },
                    { 663178888, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9847), 803819439, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9848) },
                    { 663178888, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9886), 854477536, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9887) },
                    { 663178888, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9754), 204487843, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9755) },
                    { 663178888, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9700), 405910848, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9701) },
                    { 663178888, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9860), 645694970, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9861) },
                    { 663178888, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9794), 973655422, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9795) },
                    { 663178888, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9781), 275385225, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9782) },
                    { 663178888, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9807), 865028623, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9808) },
                    { 663178888, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9741), 850953975, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9743) },
                    { 663178888, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9713), 417321741, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9714) },
                    { 663178888, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9687), 250950850, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9688) },
                    { 663178888, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9726), 348924351, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9727) },
                    { 663178888, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9820), 143425475, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9821) },
                    { 663178888, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9834), 736026665, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9835) },
                    { 663178888, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9873), 139437725, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9874) },
                    { 663178888, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9767), 864109580, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9769) },
                    { 804313112, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1331), 601521841, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1332) },
                    { 804313112, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1371), 805152450, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1372) },
                    { 804313112, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1239), 794734248, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1241) },
                    { 804313112, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1187), 894462763, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1188) },
                    { 804313112, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1344), 343672319, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1345) },
                    { 804313112, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1279), 697445963, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1280) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 804313112, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1265), 844849479, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1267) },
                    { 804313112, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1292), 668472100, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1293) },
                    { 804313112, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1226), 241598565, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1227) },
                    { 804313112, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1200), 520401601, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1201) },
                    { 804313112, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1174), 445437490, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1175) },
                    { 804313112, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1213), 490319550, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1214) },
                    { 804313112, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1305), 683672761, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1306) },
                    { 804313112, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1318), 455819746, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1319) },
                    { 804313112, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1356), 863550747, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1358) },
                    { 804313112, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1252), 807889268, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1254) },
                    { 863756784, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4285), 702882277, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4286) },
                    { 863756784, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4324), 193427118, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4326) },
                    { 863756784, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4192), 823268890, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4194) },
                    { 863756784, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4140), 357679216, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4141) },
                    { 863756784, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4298), 539434718, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4299) },
                    { 863756784, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4232), 930093602, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4233) },
                    { 863756784, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4219), 523577941, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4220) },
                    { 863756784, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4245), 186841176, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4246) },
                    { 863756784, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4179), 358409751, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4180) },
                    { 863756784, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4153), 493336255, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4154) },
                    { 863756784, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4127), 299457130, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4128) },
                    { 863756784, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4166), 749510695, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4167) },
                    { 863756784, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4259), 519530665, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4260) },
                    { 863756784, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4272), 587351410, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4273) },
                    { 863756784, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4311), 315819115, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4312) },
                    { 863756784, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4206), 379848592, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4207) },
                    { 1003449224, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8575), 849539144, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8576) },
                    { 1003449224, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8617), 870978726, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8618) },
                    { 1003449224, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8482), 205456807, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8484) },
                    { 1003449224, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8430), 688059278, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8431) },
                    { 1003449224, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8587), 567968466, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8589) },
                    { 1003449224, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8521), 716770507, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8523) },
                    { 1003449224, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8508), 313331621, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8510) },
                    { 1003449224, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8534), 380686900, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8535) },
                    { 1003449224, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8469), 740809696, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8470) },
                    { 1003449224, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8443), 157727000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8444) },
                    { 1003449224, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8416), 340403499, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8417) },
                    { 1003449224, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8456), 141500449, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8457) },
                    { 1003449224, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8547), 364447943, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8548) },
                    { 1003449224, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8561), 192784143, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8563) },
                    { 1003449224, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8600), 903891502, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8602) },
                    { 1003449224, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8495), 169009347, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8497) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1009618680, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8787), 756936316, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8788) },
                    { 1009618680, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8827), 394896941, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8828) },
                    { 1009618680, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8696), 911057605, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8697) },
                    { 1009618680, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8643), 250610056, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8645) },
                    { 1009618680, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8800), 739331263, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8801) },
                    { 1009618680, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8735), 670855274, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8736) },
                    { 1009618680, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8722), 620602596, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8723) },
                    { 1009618680, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8748), 750608342, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8749) },
                    { 1009618680, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8683), 749426150, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8684) },
                    { 1009618680, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8657), 304183183, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8658) },
                    { 1009618680, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8630), 586688616, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8632) },
                    { 1009618680, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8670), 723191016, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8671) },
                    { 1009618680, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8761), 956023943, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8762) },
                    { 1009618680, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8774), 397885168, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8775) },
                    { 1009618680, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8813), 193961145, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8814) },
                    { 1009618680, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8709), 765020569, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8710) },
                    { 1040116512, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1116), 484247984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1118) },
                    { 1040116512, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1156), 962002898, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1158) },
                    { 1040116512, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1026), 781020803, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1027) },
                    { 1040116512, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(973), 924516244, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(975) },
                    { 1040116512, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1130), 720983268, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1131) },
                    { 1040116512, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1064), 346094684, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1065) },
                    { 1040116512, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1051), 157513624, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1053) },
                    { 1040116512, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1077), 799627057, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1078) },
                    { 1040116512, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1013), 406402947, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1014) },
                    { 1040116512, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(986), 650964539, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(988) },
                    { 1040116512, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(956), 933065003, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(957) },
                    { 1040116512, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1000), 153036186, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1001) },
                    { 1040116512, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1090), 621560685, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1091) },
                    { 1040116512, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1103), 899702521, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1104) },
                    { 1040116512, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1143), 865451733, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1144) },
                    { 1040116512, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1038), 358548879, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1040) },
                    { 1042653064, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3439), 391699460, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3440) },
                    { 1042653064, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3478), 636457810, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3479) },
                    { 1042653064, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3346), 737198544, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3347) },
                    { 1042653064, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3294), 971354639, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3295) },
                    { 1042653064, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3452), 665688127, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3453) },
                    { 1042653064, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3385), 994836029, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3386) },
                    { 1042653064, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3372), 361437599, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3374) },
                    { 1042653064, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3398), 755338239, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3400) },
                    { 1042653064, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3333), 403706411, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3334) },
                    { 1042653064, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3307), 759825430, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3308) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1042653064, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3281), 787194588, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3282) },
                    { 1042653064, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3320), 508710820, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3321) },
                    { 1042653064, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3412), 636728420, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3413) },
                    { 1042653064, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3425), 791733494, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3426) },
                    { 1042653064, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3465), 591532924, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3466) },
                    { 1042653064, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3359), 824657882, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3360) },
                    { 1112010912, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2175), 817358408, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2176) },
                    { 1112010912, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2214), 450250304, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2215) },
                    { 1112010912, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2084), 137217773, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2085) },
                    { 1112010912, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2032), 289642620, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2033) },
                    { 1112010912, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2188), 814735923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2189) },
                    { 1112010912, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2123), 241321876, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2124) },
                    { 1112010912, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2110), 174371009, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2111) },
                    { 1112010912, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2136), 199184860, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2137) },
                    { 1112010912, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2071), 792297759, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2072) },
                    { 1112010912, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2045), 797286218, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2046) },
                    { 1112010912, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2019), 495273809, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2020) },
                    { 1112010912, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2058), 236745120, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2059) },
                    { 1112010912, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2148), 658508382, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2150) },
                    { 1112010912, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2162), 647555049, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2163) },
                    { 1112010912, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2201), 657519321, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2202) },
                    { 1112010912, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2097), 153218520, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2098) },
                    { 1271275656, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1752), 507714664, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1754) },
                    { 1271275656, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1792), 249393535, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1793) },
                    { 1271275656, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1661), 242288181, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1662) },
                    { 1271275656, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1609), 507009772, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1610) },
                    { 1271275656, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1766), 896220755, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1767) },
                    { 1271275656, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1700), 711270046, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1701) },
                    { 1271275656, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1687), 402372569, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1688) },
                    { 1271275656, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1713), 795374464, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1714) },
                    { 1271275656, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1647), 260166170, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1649) },
                    { 1271275656, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1622), 891468993, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1623) },
                    { 1271275656, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1596), 591174914, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1597) },
                    { 1271275656, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1635), 133496908, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1636) },
                    { 1271275656, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1726), 921078366, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1728) },
                    { 1271275656, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1739), 294000709, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1740) },
                    { 1271275656, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1779), 393856867, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1780) },
                    { 1271275656, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1674), 268884556, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1675) },
                    { 1347717952, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9634), 596985385, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9635) },
                    { 1347717952, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9673), 480472107, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9674) },
                    { 1347717952, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9541), 578621184, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9543) },
                    { 1347717952, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9489), 468318456, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9490) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1347717952, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9646), 962460514, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9648) },
                    { 1347717952, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9582), 164958591, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9583) },
                    { 1347717952, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9569), 362611520, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9570) },
                    { 1347717952, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9595), 932404841, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9596) },
                    { 1347717952, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9528), 667159468, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9529) },
                    { 1347717952, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9502), 955335469, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9503) },
                    { 1347717952, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9476), 379730434, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9477) },
                    { 1347717952, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9515), 315553327, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9516) },
                    { 1347717952, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9608), 594563281, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9609) },
                    { 1347717952, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9621), 268352239, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9622) },
                    { 1347717952, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9659), 205216352, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9660) },
                    { 1347717952, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9555), 165367847, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(9556) },
                    { 1363207760, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4074), 460851900, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4075) },
                    { 1363207760, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4113), 137697579, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4114) },
                    { 1363207760, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3977), 985434368, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3978) },
                    { 1363207760, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3925), 367996509, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3926) },
                    { 1363207760, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4087), 726815679, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4088) },
                    { 1363207760, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4016), 556832070, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4017) },
                    { 1363207760, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4003), 332062027, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4004) },
                    { 1363207760, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4034), 854783944, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4035) },
                    { 1363207760, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3964), 132020985, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3965) },
                    { 1363207760, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3938), 516359834, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3939) },
                    { 1363207760, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3912), 368219693, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3913) },
                    { 1363207760, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3951), 572388803, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3952) },
                    { 1363207760, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4047), 215331907, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4048) },
                    { 1363207760, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4060), 500151476, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4061) },
                    { 1363207760, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4100), 173385302, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(4101) },
                    { 1363207760, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3990), 179068149, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3991) },
                    { 1485083712, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2598), 298569534, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2599) },
                    { 1485083712, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2636), 405793096, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2637) },
                    { 1485083712, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2507), 352816985, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2508) },
                    { 1485083712, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2454), 939459813, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2455) },
                    { 1485083712, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2611), 383969085, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2612) },
                    { 1485083712, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2545), 140738448, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2547) },
                    { 1485083712, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2533), 578513145, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2534) },
                    { 1485083712, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2558), 521059562, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2559) },
                    { 1485083712, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2493), 673163548, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2495) },
                    { 1485083712, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2467), 669144666, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2468) },
                    { 1485083712, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2441), 611645047, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2442) },
                    { 1485083712, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2480), 576146910, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2482) },
                    { 1485083712, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2571), 674738757, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2572) },
                    { 1485083712, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2584), 419097673, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2586) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1485083712, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2623), 987851011, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2625) },
                    { 1485083712, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2520), 339157538, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2521) },
                    { 1560873936, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1541), 983916350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1543) },
                    { 1560873936, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1583), 446817437, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1584) },
                    { 1560873936, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1449), 645344779, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1450) },
                    { 1560873936, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1397), 172193590, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1398) },
                    { 1560873936, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1554), 856590333, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1556) },
                    { 1560873936, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1488), 855479940, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1489) },
                    { 1560873936, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1475), 619534121, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1476) },
                    { 1560873936, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1501), 186735774, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1502) },
                    { 1560873936, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1436), 349787121, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1437) },
                    { 1560873936, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1410), 206313090, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1411) },
                    { 1560873936, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1384), 171317337, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1385) },
                    { 1560873936, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1423), 899700907, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1424) },
                    { 1560873936, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1514), 158882600, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1516) },
                    { 1560873936, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1527), 149563890, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1529) },
                    { 1560873936, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1567), 609248097, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1569) },
                    { 1560873936, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1462), 132989260, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(1463) },
                    { 1581735624, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8149), 486639230, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8150) },
                    { 1581735624, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8188), 291969539, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8189) },
                    { 1581735624, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8058), 335756350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8059) },
                    { 1581735624, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8005), 449778397, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8006) },
                    { 1581735624, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8162), 893614266, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8163) },
                    { 1581735624, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8096), 718014979, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8098) },
                    { 1581735624, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8084), 351027570, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8085) },
                    { 1581735624, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8110), 202294380, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8111) },
                    { 1581735624, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8044), 954325841, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8045) },
                    { 1581735624, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8018), 399557678, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8019) },
                    { 1581735624, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7990), 392201005, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7992) },
                    { 1581735624, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8031), 689716120, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8032) },
                    { 1581735624, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8123), 399902822, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8124) },
                    { 1581735624, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8136), 632904249, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8137) },
                    { 1581735624, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8175), 312358569, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8176) },
                    { 1581735624, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8071), 857939039, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8072) },
                    { 1647354272, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8363), 862837748, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8364) },
                    { 1647354272, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8402), 136272498, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8403) },
                    { 1647354272, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8269), 215330960, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8270) },
                    { 1647354272, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8214), 579856570, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8215) },
                    { 1647354272, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8376), 712988978, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8377) },
                    { 1647354272, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8309), 879921868, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8311) },
                    { 1647354272, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8296), 447933827, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8298) },
                    { 1647354272, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8323), 165684215, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8324) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1647354272, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8256), 722333203, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8257) },
                    { 1647354272, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8227), 484496749, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8228) },
                    { 1647354272, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8201), 405935694, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8202) },
                    { 1647354272, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8241), 574073150, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8242) },
                    { 1647354272, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8337), 969495058, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8338) },
                    { 1647354272, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8349), 843177959, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8351) },
                    { 1647354272, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8389), 472285071, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8390) },
                    { 1647354272, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8283), 159315108, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(8284) },
                    { 1738146864, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3017), 125242151, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3019) },
                    { 1738146864, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3056), 324618556, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3058) },
                    { 1738146864, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2926), 207360403, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2927) },
                    { 1738146864, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2873), 268710290, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2874) },
                    { 1738146864, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3030), 631460626, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3032) },
                    { 1738146864, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2965), 355361116, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2966) },
                    { 1738146864, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2952), 848741418, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2953) },
                    { 1738146864, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2978), 430368227, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2979) },
                    { 1738146864, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2913), 291196686, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2914) },
                    { 1738146864, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2886), 315922194, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2887) },
                    { 1738146864, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2860), 824842778, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2861) },
                    { 1738146864, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2899), 590902179, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2900) },
                    { 1738146864, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2991), 632062436, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2992) },
                    { 1738146864, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3004), 799749342, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3005) },
                    { 1738146864, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3044), 459518670, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(3045) },
                    { 1738146864, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2939), 901953635, new DateTime(2024, 4, 3, 17, 27, 57, 464, DateTimeKind.Local).AddTicks(2940) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 124962616, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4253), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4250), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4252), 621147985 },
                    { 134875383, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3353), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3351), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3352), 905688991 },
                    { 149064032, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4181), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4179), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4180), 268459121 },
                    { 154067998, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3200), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3197), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3198), 621147985 },
                    { 167629925, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3128), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3126), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3127), 268459121 },
                    { 170369034, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3430), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3427), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3428), 268459121 },
                    { 174276646, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3043), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3041), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3042), 268459121 },
                    { 187431841, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3687), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3685), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3686), 621147985 },
                    { 191565139, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4340), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4337), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4338), 621147985 },
                    { 198745942, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4224), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4222), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4223), 268459121 },
                    { 202538401, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3659), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3656), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3657), 268459121 },
                    { 208966557, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4139), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4136), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4138), 268459121 },
                    { 210976313, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4268), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4265), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4267), 268459121 },
                    { 217668858, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4296), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4294), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4295), 621147985 },
                    { 238736083, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3733), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3731), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3732), 621147985 },
                    { 240324977, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3791), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3788), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3789), 268459121 },
                    { 305490982, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3921), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3919), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3920), 268459121 },
                    { 305525026, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3616), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3613), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3614), 268459121 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 308937919, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4007), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4004), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4006), 268459121 },
                    { 355453931, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3935), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3933), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3934), 905688991 },
                    { 357561391, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4024), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4022), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4023), 905688991 },
                    { 358114187, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3601), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3599), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3600), 621147985 },
                    { 368336922, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3312), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3309), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3310), 905688991 },
                    { 389855105, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4355), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4352), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4353), 268459121 },
                    { 395505456, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4096), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4093), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4094), 268459121 },
                    { 397392310, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3142), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3139), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3141), 905688991 },
                    { 398409098, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3573), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3570), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3571), 268459121 },
                    { 411684453, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4311), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4309), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4310), 268459121 },
                    { 425128286, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3833), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3831), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3832), 268459121 },
                    { 425705365, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3558), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3556), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3557), 621147985 },
                    { 436723459, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4325), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4323), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4324), 905688991 },
                    { 447486046, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4210), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4207), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4208), 621147985 },
                    { 453066091, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4038), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4036), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4037), 621147985 },
                    { 468089696, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4371), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4368), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4370), 905688991 },
                    { 470936158, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4067), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4064), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4066), 905688991 },
                    { 480559506, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3702), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3700), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3701), 268459121 },
                    { 482381202, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3864), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3861), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3863), 621147985 },
                    { 484839992, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3372), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3369), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3371), 621147985 },
                    { 488125521, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3978), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3976), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3977), 905688991 },
                    { 494495463, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4239), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4236), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4237), 905688991 },
                    { 509256910, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3011), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3008), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3009), 905688991 },
                    { 509730808, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4282), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4280), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4281), 905688991 },
                    { 528671076, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2902), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2898), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2900), 268459121 },
                    { 534365522, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3847), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3845), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3846), 905688991 },
                    { 535025796, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3748), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3745), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3746), 268459121 },
                    { 557440907, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3416), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3413), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3414), 621147985 },
                    { 576342533, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3186), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3183), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3185), 905688991 },
                    { 577149556, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4385), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4383), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4384), 621147985 },
                    { 579871136, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3100), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3098), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3099), 905688991 },
                    { 597796558, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3949), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3947), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3948), 621147985 },
                    { 618169414, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3214), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3212), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3213), 268459121 },
                    { 618194190, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2935), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2933), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2934), 621147985 },
                    { 629748868, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3879), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3876), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3877), 268459121 },
                    { 635916297, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3893), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3890), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3891), 905688991 },
                    { 638306965, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4124), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4122), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4123), 621147985 },
                    { 640262755, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3544), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3542), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3543), 905688991 },
                    { 642844893, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3673), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3671), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3672), 905688991 },
                    { 657315374, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3776), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3774), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3775), 621147985 },
                    { 658107996, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3964), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3961), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3962), 268459121 },
                    { 661672359, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3256), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3253), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3254), 268459121 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 673604977, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3283), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3281), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3282), 621147985 },
                    { 694418522, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3630), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3627), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3629), 905688991 },
                    { 697157144, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3473), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3470), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3471), 621147985 },
                    { 714133880, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3907), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3904), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3906), 621147985 },
                    { 721334025, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3270), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3267), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3268), 905688991 },
                    { 730840324, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4081), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4078), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4080), 621147985 },
                    { 732381963, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3762), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3759), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3761), 905688991 },
                    { 749691619, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3993), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3990), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3991), 621147985 },
                    { 752207741, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3340), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3337), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3338), 268459121 },
                    { 763532716, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4109), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4107), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4108), 905688991 },
                    { 765098637, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2996), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2994), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2995), 268459121 },
                    { 768956643, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3228), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3225), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3226), 905688991 },
                    { 780447909, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3242), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3239), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3241), 621147985 },
                    { 789364609, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3388), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3385), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3387), 268459121 },
                    { 805992625, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3158), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3155), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3156), 621147985 },
                    { 813375105, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3501), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3499), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3500), 905688991 },
                    { 821010010, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4167), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4165), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4166), 621147985 },
                    { 821489637, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2982), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2979), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2980), 621147985 },
                    { 832863459, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3072), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3069), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3071), 621147985 },
                    { 836655034, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3716), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3714), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3715), 905688991 },
                    { 845371493, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3487), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3485), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3486), 268459121 },
                    { 855790165, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3530), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3527), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3528), 268459121 },
                    { 855935194, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3057), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3055), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3056), 905688991 },
                    { 856709214, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3027), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3025), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3026), 621147985 },
                    { 883902745, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4053), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4050), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4052), 268459121 },
                    { 905813041, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3325), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3323), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3324), 621147985 },
                    { 949071983, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4195), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4193), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4194), 905688991 },
                    { 949445103, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2921), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2918), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2919), 905688991 },
                    { 957738889, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3114), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3112), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3113), 621147985 },
                    { 958617086, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3298), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3295), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3296), 268459121 },
                    { 959996568, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3402), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3400), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3401), 905688991 },
                    { 960346769, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4153), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4150), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4152), 905688991 },
                    { 964815769, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3515), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3513), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3514), 621147985 },
                    { 968907784, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2966), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2963), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2964), 905688991 },
                    { 971592182, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3805), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3802), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3804), 905688991 },
                    { 973101106, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3819), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3816), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3817), 621147985 },
                    { 978912539, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3644), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3642), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3643), 621147985 },
                    { 983243060, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3458), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3456), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3457), 905688991 },
                    { 984082660, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3086), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3083), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3085), 268459121 },
                    { 985776532, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2951), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2948), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2950), 268459121 },
                    { 987653116, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3172), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3170), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3171), 268459121 },
                    { 995498421, new DateTime(2024, 4, 14, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3587), 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3584), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3585), 905688991 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 123779158, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5884), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5885), 558966587 },
                    { 129062326, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5144), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5145), 165955446 },
                    { 135433333, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6305), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6306), 165955446 },
                    { 143499876, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6152), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6153), 558966587 },
                    { 151234379, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7102), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7103), 165955446 },
                    { 155533676, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6875), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6877), 828779598 },
                    { 160155115, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6011), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6012), 845528590 },
                    { 164750292, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6938), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6939), 400712125 },
                    { 165036541, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6926), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6927), 165955446 },
                    { 166566038, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5909), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5910), 239928411 },
                    { 174657185, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6520), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6521), 828779598 },
                    { 183860018, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7475), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7476), 400712125 },
                    { 186524388, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6179), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6180), 239928411 },
                    { 186957318, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6570), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6572), 165955446 },
                    { 195810411, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7397), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7398), 558966587 },
                    { 198777087, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6329), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6330), 558966587 },
                    { 208639835, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5934), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5935), 538780288 },
                    { 213989920, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6545), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6546), 845528590 },
                    { 218226258, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5896), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5898), 828779598 },
                    { 218795483, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4774), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4775), 538780288 },
                    { 220778674, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4577), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4578), 845528590 },
                    { 222177115, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6583), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6584), 400712125 },
                    { 224004129, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6354), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6356), 239928411 },
                    { 225017939, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7001), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7002), 538780288 },
                    { 231387620, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7372), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7373), 165955446 },
                    { 232335848, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7504), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7506), 828779598 },
                    { 234474074, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4536), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4537), 558966587 },
                    { 241325350, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4814), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4815), 558966587 },
                    { 244142336, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7346), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7347), 845528590 },
                    { 251573968, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7196), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7198), 165955446 },
                    { 272148004, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6825), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6826), 538780288 },
                    { 276515188, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7089), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7090), 538780288 },
                    { 276755830, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7435), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7436), 845528590 },
                    { 293843631, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5077), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5078), 558966587 },
                    { 294245615, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6721), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6722), 845528590 },
                    { 303128737, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6963), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6965), 828779598 },
                    { 307168269, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5245), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5246), 400712125 },
                    { 307287114, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4839), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4840), 239928411 },
                    { 310615128, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4682), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4683), 538780288 },
                    { 316252156, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5015), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5016), 239928411 },
                    { 316378498, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4889), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4890), 400712125 },
                    { 325872915, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6087), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6088), 239928411 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 327290784, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6658), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6659), 165955446 },
                    { 328236513, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6113), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6114), 538780288 },
                    { 330650587, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7384), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7385), 400712125 },
                    { 340633654, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5653), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5655), 845528590 },
                    { 340671727, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5089), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5090), 828779598 },
                    { 341906838, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6407), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6408), 400712125 },
                    { 343379604, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6367), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6368), 845528590 },
                    { 347427052, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5553), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5554), 239928411 },
                    { 348249847, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5334), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5335), 400712125 },
                    { 348703596, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5465), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5466), 239928411 },
                    { 349690858, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6850), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6852), 400712125 },
                    { 357278544, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4787), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4788), 165955446 },
                    { 358959070, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6379), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6380), 538780288 },
                    { 359520439, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6317), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6318), 400712125 },
                    { 360340914, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6900), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6902), 845528590 },
                    { 361348415, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5960), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5961), 400712125 },
                    { 361834608, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7145), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7147), 828779598 },
                    { 363189171, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7115), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7116), 400712125 },
                    { 367789172, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6746), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6747), 165955446 },
                    { 368694624, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5386), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5387), 845528590 },
                    { 381790303, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6762), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6763), 400712125 },
                    { 382297506, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7221), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7222), 558966587 },
                    { 384283021, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7271), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7272), 538780288 },
                    { 384863523, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6708), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6709), 239928411 },
                    { 385985378, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4655), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4656), 239928411 },
                    { 387279782, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6267), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6268), 239928411 },
                    { 387750983, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6292), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6293), 538780288 },
                    { 388306512, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5283), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5285), 239928411 },
                    { 392944562, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6254), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6255), 828779598 },
                    { 395411859, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5833), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5834), 845528590 },
                    { 396606673, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6733), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6735), 538780288 },
                    { 400118449, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6812), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6813), 845528590 },
                    { 402296103, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5452), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5454), 828779598 },
                    { 403491516, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7158), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7159), 239928411 },
                    { 403628728, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6533), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6534), 239928411 },
                    { 405852226, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7359), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7360), 538780288 },
                    { 409470672, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6074), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6075), 828779598 },
                    { 416318345, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7321), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7322), 828779598 },
                    { 419040370, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6683), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6685), 558966587 },
                    { 426615968, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7171), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7172), 845528590 },
                    { 442485834, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4926), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4927), 239928411 },
                    { 446451407, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5666), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5667), 538780288 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 448488740, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5871), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5872), 400712125 },
                    { 450514962, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4522), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4523), 400712125 },
                    { 450817633, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7460), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7462), 165955446 },
                    { 450963025, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4506), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4507), 165955446 },
                    { 454928950, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4863), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4864), 538780288 },
                    { 464887525, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6242), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6243), 558966587 },
                    { 468157451, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5027), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5029), 845528590 },
                    { 468700217, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7259), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7260), 845528590 },
                    { 472592888, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4761), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4763), 845528590 },
                    { 494372978, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6036), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6038), 165955446 },
                    { 494727343, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4965), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4966), 165955446 },
                    { 497451537, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7077), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7078), 845528590 },
                    { 499962785, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6671), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6672), 400712125 },
                    { 503114400, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5717), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5718), 828779598 },
                    { 507827480, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6204), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6205), 538780288 },
                    { 509200191, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6620), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6621), 239928411 },
                    { 511423709, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7039), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7040), 558966587 },
                    { 515932742, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4799), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4800), 400712125 },
                    { 516255646, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4977), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4979), 400712125 },
                    { 516745957, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4720), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4721), 558966587 },
                    { 521976127, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6787), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6788), 828779598 },
                    { 524381523, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4952), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4954), 538780288 },
                    { 527470795, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7064), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7065), 239928411 },
                    { 530581070, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5591), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5592), 165955446 },
                    { 534755528, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5361), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5362), 828779598 },
                    { 537351025, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7209), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7210), 400712125 },
                    { 540457053, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7517), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7518), 239928411 },
                    { 545273076, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5373), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5375), 239928411 },
                    { 548390001, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5566), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5567), 845528590 },
                    { 554038661, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6392), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6393), 165955446 },
                    { 555522930, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5603), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5604), 400712125 },
                    { 557639103, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6607), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6609), 828779598 },
                    { 558102315, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5156), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5158), 400712125 },
                    { 558716322, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6166), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6167), 828779598 },
                    { 568279206, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5858), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5859), 165955446 },
                    { 571164477, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5767), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5768), 165955446 },
                    { 574456828, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6217), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6218), 165955446 },
                    { 576111181, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4616), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4617), 400712125 },
                    { 580923638, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6508), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6509), 558966587 },
                    { 581333389, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4826), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4827), 828779598 },
                    { 586220159, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5440), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5441), 558966587 },
                    { 596953009, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5691), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5692), 400712125 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 604104930, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4901), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4902), 558966587 },
                    { 604523646, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4630), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4631), 558966587 },
                    { 604716533, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5131), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5132), 538780288 },
                    { 605124905, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7308), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7310), 558966587 },
                    { 607280725, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5679), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5680), 165955446 },
                    { 608330966, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6951), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6952), 558966587 },
                    { 609481048, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5540), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5542), 828779598 },
                    { 609641724, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5921), -1514757176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5923), 845528590 },
                    { 612589876, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7296), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7297), 400712125 },
                    { 619140796, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6495), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6497), 400712125 },
                    { 634457811, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4914), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4915), 828779598 },
                    { 640048418, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7026), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7027), 400712125 },
                    { 647676403, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6838), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6839), 165955446 },
                    { 648307391, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5528), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5529), 558966587 },
                    { 651860505, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6775), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6776), 558966587 },
                    { 652402614, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5182), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5183), 828779598 },
                    { 657735897, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7183), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7185), 538780288 },
                    { 657804072, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5296), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5297), 845528590 },
                    { 667622015, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7543), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7544), 538780288 },
                    { 671385164, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5399), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5400), 538780288 },
                    { 672375138, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6125), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6127), 165955446 },
                    { 675114425, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4747), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4748), 239928411 },
                    { 675681812, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5427), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5428), 400712125 },
                    { 686091042, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5783), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5784), 400712125 },
                    { 688843305, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4708), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4709), 400712125 },
                    { 690015103, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4940), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4941), 845528590 },
                    { 691533877, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5321), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5323), 165955446 },
                    { 703344763, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7234), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7235), 828779598 },
                    { 703402816, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7492), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7493), 558966587 },
                    { 703808950, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6342), -1819396000, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6343), 828779598 },
                    { 705030604, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6800), 1738146864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6801), 239928411 },
                    { 705500169, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5704), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5705), 558966587 },
                    { 715403451, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5845), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5847), 538780288 },
                    { 716371089, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7530), -1409396880, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7531), 845528590 },
                    { 719085622, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6140), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6141), 400712125 },
                    { 721620071, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6432), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6434), 828779598 },
                    { 731356297, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5309), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5310), 538780288 },
                    { 731512577, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7246), 1363207760, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7247), 239928411 },
                    { 736122187, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6420), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6421), 558966587 },
                    { 738659404, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6888), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6889), 239928411 },
                    { 742631840, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6633), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6634), 845528590 },
                    { 743209078, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5973), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5974), 558966587 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 744042279, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5729), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5730), 239928411 },
                    { 747348427, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6470), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6471), 538780288 },
                    { 750793245, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6280), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6281), 845528590 },
                    { 754570227, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6558), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6559), 538780288 },
                    { 755070776, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6445), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6446), 239928411 },
                    { 759050912, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6645), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6647), 538780288 },
                    { 760788561, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5629), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5630), 828779598 },
                    { 763946557, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6023), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6025), 538780288 },
                    { 766180293, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4549), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4550), 828779598 },
                    { 771063762, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7133), -2083657472, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7134), 558966587 },
                    { 771477665, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5795), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5797), 558966587 },
                    { 775334700, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5220), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5221), 538780288 },
                    { 777091264, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5516), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5517), 400712125 },
                    { 786877207, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4643), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4644), 828779598 },
                    { 790992055, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5119), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5120), 845528590 },
                    { 795830494, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5052), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5054), 165955446 },
                    { 796095798, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5808), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5809), 828779598 },
                    { 796178448, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5207), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5208), 845528590 },
                    { 800588438, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5820), -775858864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5822), 239928411 },
                    { 801494438, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5106), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5107), 239928411 },
                    { 804626581, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5348), 1347717952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5349), 558966587 },
                    { 808275314, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7447), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7448), 538780288 },
                    { 808545915, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6049), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6050), 400712125 },
                    { 818149233, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5477), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5479), 845528590 },
                    { 823950754, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6062), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6063), 558966587 },
                    { 824138200, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5616), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5617), 558966587 },
                    { 829438147, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5414), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5416), 165955446 },
                    { 829819317, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6595), 1485083712, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6596), 558966587 },
                    { 834250872, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5003), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5004), 828779598 },
                    { 834731864, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6483), -2011520240, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6484), 165955446 },
                    { 837707356, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5065), -962818952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5066), 400712125 },
                    { 845626475, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6696), -1421860816, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6697), 828779598 },
                    { 847331467, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5947), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5948), 165955446 },
                    { 862001372, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6976), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6977), 239928411 },
                    { 862904452, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4734), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4735), 828779598 },
                    { 865086744, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4990), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4991), 558966587 },
                    { 867753101, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5490), 663178888, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5491), 538780288 },
                    { 873256908, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5578), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5579), 538780288 },
                    { 880417552, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4668), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4669), 845528590 },
                    { 886261709, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5998), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5999), 239928411 },
                    { 893890128, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6863), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6864), 558966587 },
                    { 894040725, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7014), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7015), 165955446 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 894381803, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5503), -1699909864, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5504), 165955446 },
                    { 908145643, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4603), -1653977944, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4604), 165955446 },
                    { 916038242, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5169), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5170), 558966587 },
                    { 916375068, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7333), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7335), 239928411 },
                    { 917940506, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5754), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5755), 538780288 },
                    { 918804266, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5233), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5234), 165955446 },
                    { 923086155, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6913), -5301200, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6914), 538780288 },
                    { 929047222, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6457), 1112010912, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6458), 845528590 },
                    { 931598603, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4876), 1003449224, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4877), 165955446 },
                    { 937067870, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4851), 1647354272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4852), 845528590 },
                    { 939914995, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7052), -633240176, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7053), 828779598 },
                    { 942829454, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4695), 1581735624, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4696), 165955446 },
                    { 947213109, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4590), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4591), 538780288 },
                    { 950869092, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6099), 804313112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6101), 845528590 },
                    { 962989232, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5271), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5272), 828779598 },
                    { 963758038, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6191), 1560873936, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6193), 845528590 },
                    { 964833529, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5986), 1040116512, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5987), 828779598 },
                    { 965060865, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5641), -1625851672, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5642), 239928411 },
                    { 968043074, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5742), 32266600, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5743), 845528590 },
                    { 969727066, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5040), 1009618680, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5041), 538780288 },
                    { 979369534, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7409), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7411), 828779598 },
                    { 982503245, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7422), -1659309952, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7423), 239928411 },
                    { 983096964, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5258), -543353784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5259), 558966587 },
                    { 984274413, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4562), 305281784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(4564), 239928411 },
                    { 986060449, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6988), 1042653064, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6990), 845528590 },
                    { 991044946, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5194), -1331637752, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(5196), 239928411 },
                    { 992906137, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7284), 863756784, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(7285), 165955446 },
                    { 994327804, 0f, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6229), 1271275656, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(6230), 400712125 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 184199148, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9876), 1846967274, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9878) },
                    { 207193490, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9890), 1781023968, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9891) },
                    { 276735076, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(17), -1493500873, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(18) },
                    { 286095180, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(89), -1618104694, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(91) },
                    { 287376144, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9945), -829349864, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9946) },
                    { 382582123, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9974), 674518442, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9975) },
                    { 416581060, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9988), 161471354, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9989) },
                    { 445875851, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9904), -1602750428, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9905) },
                    { 500430058, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(103), -1555507655, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(104) },
                    { 568362095, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(62), -1402721392, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(63) },
                    { 576092191, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9960), -681723859, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9961) },
                    { 593781710, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9931), 863151422, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9933) },
                    { 676506509, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(2), -2015868725, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(3) },
                    { 700824785, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9918), -1102583933, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9919) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 770998996, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(76), 1651293675, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(77) },
                    { 854210932, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(30), 279601093, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(32) },
                    { 937022600, 373775857, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(47), -1180280263, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(48) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9349), false, false, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9350), "Secretariat", 373775857 },
                    { 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9363), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9364), "Project Manager", 373775857 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 373775857, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1040), 878381395, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1041) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 184199148, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(444), -1880958428, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(446) },
                    { 207193490, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(458), 1349928986, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(460) },
                    { 287376144, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(487), 569179796, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(488) },
                    { 382582123, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(515), 687734267, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(517) },
                    { 576092191, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(501), -1584985603, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(502) },
                    { 593781710, 295922470, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(473), -1948246145, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(474) },
                    { 184199148, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9603), -1067153791, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9604) },
                    { 207193490, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9617), -1233275561, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9618) },
                    { 279505313, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9635), -1104625345, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9636) },
                    { 287376144, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9663), -253986137, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9664) },
                    { 500430058, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9722), 819703463, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9723) },
                    { 576092191, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9678), -1696040720, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9679) },
                    { 593781710, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9649), -702366623, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9650) },
                    { 788963579, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9706), -944669668, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9707) },
                    { 937022600, 643119039, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9692), 255127798, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9693) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9379), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9380), "Engineer", 643119039 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 643119039, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1586), 150209089, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1587) },
                    { 643119039, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1600), 176785622, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1601) },
                    { 643119039, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1570), 120985872, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1571) },
                    { 295922470, 783169759, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(590), 951995374, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(591) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 184199148, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9516), 1448709755, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9517) },
                    { 207193490, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9530), 1280375753, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9531) },
                    { 287376144, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9574), -2138053225, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9575) },
                    { 382237209, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9545), 1280661795, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9546) },
                    { 576092191, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9587), -2008678468, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9589) },
                    { 593781710, 686632053, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9560), -1287703673, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9561) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 235327477, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9393), false, true, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9395), "Designer", 686632053 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 686632053, 138517350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1349), 371536484, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1350) },
                    { 686632053, 220858511, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1474), 804957350, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1475) },
                    { 686632053, 271869663, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1012), 175269652, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1013) },
                    { 686632053, 281876897, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(821), 138718836, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(822) },
                    { 686632053, 356120023, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1391), 569018817, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1392) },
                    { 686632053, 363478825, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1172), 759910768, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1173) },
                    { 686632053, 480985555, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1126), 568946036, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1127) },
                    { 686632053, 549298984, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1216), 516510409, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1217) },
                    { 686632053, 604317923, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(954), 783410318, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(955) },
                    { 686632053, 640869632, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(864), 831216365, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(865) },
                    { 686632053, 648344074, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(772), 522305456, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(774) },
                    { 686632053, 660865722, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(908), 973849308, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(910) },
                    { 686632053, 770084161, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1260), 137276208, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1262) },
                    { 686632053, 790206202, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1304), 342919611, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1305) },
                    { 686632053, 848034177, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1433), 481227806, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1434) },
                    { 686632053, 883028983, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1083), 170890112, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(1084) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 184199148, 235327477, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9451), -1071231898, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9452) },
                    { 207193490, 235327477, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9473), -993206402, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9475) },
                    { 593781710, 235327477, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9487), 309892006, new DateTime(2024, 4, 3, 17, 27, 57, 462, DateTimeKind.Local).AddTicks(9488) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 235327477, 608823485, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(640), 164504094, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(641) },
                    { 235327477, 729039359, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(682), 409715272, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(684) },
                    { 235327477, 821016946, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(727), 824989116, new DateTime(2024, 4, 3, 17, 27, 57, 463, DateTimeKind.Local).AddTicks(729) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IssueId",
                table: "Documents",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Roles_DisplayedRoleId",
                table: "Issues",
                column: "DisplayedRoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Roles_DisplayedRoleId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2083657472, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -2011520240, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1819396000, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1699909864, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1659309952, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1653977944, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1625851672, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1514757176, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1421860816, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -1331637752, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -962818952, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -775858864, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -633240176, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -543353784, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { -5301200, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 32266600, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 305281784, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 663178888, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 804313112, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 863756784, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1003449224, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1009618680, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1040116512, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1042653064, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1112010912, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1271275656, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1347717952, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1363207760, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1485083712, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1560873936, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1581735624, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1647354272, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 138517350 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 220858511 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 271869663 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 281876897 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 356120023 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 363478825 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 480985555 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 549298984 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 604317923 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 640869632 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 648344074 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 660865722 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 770084161 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 790206202 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 848034177 });

            migrationBuilder.DeleteData(
                table: "DisciplineEngineer",
                keyColumns: new[] { "DisciplineId", "EngineerId" },
                keyValues: new object[] { 1738146864, 883028983 });

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 427368052);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 434918733);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 791021286);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 885071061);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 124962616);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 134875383);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 149064032);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 154067998);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 167629925);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 170369034);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 174276646);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 187431841);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 191565139);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 198745942);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 202538401);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 208966557);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 210976313);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 217668858);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 238736083);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 240324977);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 305490982);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 305525026);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 308937919);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 355453931);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 357561391);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 358114187);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 368336922);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 389855105);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 395505456);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 397392310);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 398409098);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 411684453);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 425128286);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 425705365);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 436723459);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 447486046);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 453066091);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 468089696);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 470936158);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 480559506);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 482381202);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 484839992);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 488125521);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 494495463);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 509256910);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 509730808);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 528671076);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 534365522);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 535025796);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 557440907);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 576342533);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 577149556);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 579871136);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 597796558);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 618169414);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 618194190);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 629748868);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 635916297);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 638306965);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 640262755);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 642844893);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 657315374);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 658107996);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 661672359);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 673604977);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 694418522);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 697157144);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 714133880);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 721334025);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 730840324);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 732381963);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 749691619);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 752207741);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 763532716);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 765098637);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 768956643);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 780447909);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 789364609);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 805992625);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 813375105);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 821010010);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 821489637);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 832863459);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 836655034);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 845371493);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 855790165);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 855935194);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 856709214);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 883902745);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 905813041);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 949071983);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 949445103);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 957738889);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 958617086);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 959996568);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 960346769);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 964815769);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 968907784);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 971592182);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 973101106);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 978912539);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 983243060);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 984082660);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 985776532);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 987653116);

            migrationBuilder.DeleteData(
                table: "Drawings",
                keyColumn: "Id",
                keyValue: 995498421);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 155561801);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 169099735);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 177377794);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 262401343);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 281876410);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 329026571);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 346323248);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 375608351);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 380736071);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 396677488);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 481496331);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 585307796);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 591069402);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 592547697);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 636996253);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 656003193);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 730958540);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 771708511);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 833003655);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 863458992);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 955377490);

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 993973775);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 141917859);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 171713976);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 288397280);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 352105424);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 444767366);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 489176939);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 516802221);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 521536590);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 751455039);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 781846729);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 843677771);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 123779158);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 129062326);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 135433333);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 143499876);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 151234379);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 155533676);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 160155115);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 164750292);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 165036541);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 166566038);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 174657185);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 183860018);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 186524388);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 186957318);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 195810411);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 198777087);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 208639835);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 213989920);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 218226258);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 218795483);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 220778674);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 222177115);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 224004129);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 225017939);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 231387620);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 232335848);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 234474074);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 241325350);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 244142336);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 251573968);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 272148004);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 276515188);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 276755830);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 293843631);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 294245615);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 303128737);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 307168269);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 307287114);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 310615128);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 316252156);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 316378498);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 325872915);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 327290784);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 328236513);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 330650587);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 340633654);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 340671727);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 341906838);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 343379604);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 347427052);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 348249847);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 348703596);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 349690858);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 357278544);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 358959070);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 359520439);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 360340914);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 361348415);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 361834608);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 363189171);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 367789172);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 368694624);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 381790303);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 382297506);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 384283021);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 384863523);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 385985378);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 387279782);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 387750983);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 388306512);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 392944562);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 395411859);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 396606673);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 400118449);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 402296103);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 403491516);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 403628728);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 405852226);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 409470672);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 416318345);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 419040370);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 426615968);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 442485834);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 446451407);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 448488740);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 450514962);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 450817633);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 450963025);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 454928950);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 464887525);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 468157451);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 468700217);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 472592888);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 494372978);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 494727343);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 497451537);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 499962785);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 503114400);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 507827480);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 509200191);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 511423709);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 515932742);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 516255646);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 516745957);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 521976127);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 524381523);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 527470795);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 530581070);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 534755528);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 537351025);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 540457053);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 545273076);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 548390001);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 554038661);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 555522930);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 557639103);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 558102315);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 558716322);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 568279206);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 571164477);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 574456828);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 576111181);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 580923638);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 581333389);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 586220159);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 596953009);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 604104930);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 604523646);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 604716533);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 605124905);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 607280725);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 608330966);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 609481048);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 609641724);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 612589876);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 619140796);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 634457811);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 640048418);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 647676403);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 648307391);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 651860505);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 652402614);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 657735897);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 657804072);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 667622015);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 671385164);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 672375138);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 675114425);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 675681812);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 686091042);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 688843305);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 690015103);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 691533877);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 703344763);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 703402816);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 703808950);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 705030604);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 705500169);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 715403451);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 716371089);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 719085622);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 721620071);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 731356297);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 731512577);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 736122187);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 738659404);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 742631840);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 743209078);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 744042279);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 747348427);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 750793245);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 754570227);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 755070776);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 759050912);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 760788561);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 763946557);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 766180293);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 771063762);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 771477665);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 775334700);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 777091264);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 786877207);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 790992055);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 795830494);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 796095798);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 796178448);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 800588438);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 801494438);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 804626581);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 808275314);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 808545915);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 818149233);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 823950754);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 824138200);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 829438147);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 829819317);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 834250872);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 834731864);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 837707356);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 845626475);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 847331467);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 862001372);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 862904452);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 865086744);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 867753101);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 873256908);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 880417552);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 886261709);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 893890128);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 894040725);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 894381803);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 908145643);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 916038242);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 916375068);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 917940506);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 918804266);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 923086155);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 929047222);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 931598603);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 937067870);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 939914995);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 942829454);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 947213109);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 950869092);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 962989232);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 963758038);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 964833529);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 965060865);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 968043074);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 969727066);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 979369534);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 982503245);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 983096964);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 984274413);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 986060449);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 991044946);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 992906137);

            migrationBuilder.DeleteData(
                table: "Others",
                keyColumn: "Id",
                keyValue: 994327804);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 235327477 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 235327477 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 235327477 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382582123, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 295922470 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 276735076, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 286095180, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382582123, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 416581060, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 445875851, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 500430058, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 568362095, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 676506509, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 700824785, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 770998996, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 854210932, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 937022600, 373775857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 384005857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382582123, 384005857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 384005857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 703873135, 384005857 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 279505313, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382237209, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382582123, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 445875851, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 510040592 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 531140448 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 279505313, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 500430058, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 788963579, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 937022600, 643119039 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 176097931, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 279505313, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 286095180, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 365719928, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382237209, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382582123, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 416581060, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 445875851, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 500430058, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 568362095, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 700824785, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 770998996, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 937022600, 650911188 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 651976103 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 184199148, 686632053 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 207193490, 686632053 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 287376144, 686632053 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 382237209, 686632053 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 576092191, 686632053 });

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 593781710, 686632053 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 138517350 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 220858511 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 373775857, 271869663 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 384005857, 271869663 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 510040592, 271869663 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 643119039, 271869663 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 271869663 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 281876897 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 356120023 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 363478825 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 480985555 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 643119039, 549298984 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 549298984 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 650911188, 604317923 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 604317923 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 235327477, 608823485 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 640869632 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 643119039, 648344074 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 648344074 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 384005857, 650236807 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 660865722 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 235327477, 729039359 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 770084161 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 295922470, 783169759 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 790206202 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 235327477, 821016946 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 848034177 });

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 686632053, 883028983 });

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2083657472);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -2011520240);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1819396000);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1699909864);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1659309952);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1653977944);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1625851672);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1514757176);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1421860816);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1409396880);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -1331637752);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -962818952);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -775858864);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -633240176);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -543353784);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: -5301200);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 32266600);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 305281784);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 663178888);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 804313112);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 863756784);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1003449224);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1009618680);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1040116512);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1042653064);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1112010912);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1271275656);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1347717952);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1363207760);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1485083712);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1560873936);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1581735624);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1647354272);

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: 1738146864);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 268459121);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 621147985);

            migrationBuilder.DeleteData(
                table: "DrawingTypes",
                keyColumn: "Id",
                keyValue: 905688991);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 165955446);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 239928411);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 400712125);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 538780288);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 558966587);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 828779598);

            migrationBuilder.DeleteData(
                table: "OtherTypes",
                keyColumn: "Id",
                keyValue: 845528590);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 176097931);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 184199148);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 207193490);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 276735076);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 279505313);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 286095180);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 287376144);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 365719928);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 382237209);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 382582123);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 416581060);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 445875851);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 500430058);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 568362095);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 576092191);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 593781710);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 676506509);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 700824785);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 703873135);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 770998996);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 788963579);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 854210932);

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: 937022600);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 235327477);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 295922470);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 384005857);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 531140448);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 651976103);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 138517350);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 220858511);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 281876897);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 356120023);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 363478825);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 480985555);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 604317923);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 608823485);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 640869632);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 650236807);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 660865722);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 729039359);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 770084161);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 783169759);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 790206202);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 821016946);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 848034177);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 883028983);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 151973675);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 229452996);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 231636455);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 265941510);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 298942904);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 305229622);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 321322402);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 383201487);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 385441638);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 548666294);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 577009269);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 699259899);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 727815759);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 761432802);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 829677651);

            migrationBuilder.DeleteData(
                table: "DisciplineTypes",
                keyColumn: "Id",
                keyValue: 949717299);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 163199002);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 290458482);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 404804570);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 412747066);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 427390014);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 466045658);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 535588583);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 564589086);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 702103121);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 747388350);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 763659356);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 916539812);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 686632053);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 328788640);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 346503376);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 578630126);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 682049824);

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: 735209553);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 643119039);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 271869663);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 549298984);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 648344074);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 373775857);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 510040592);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 650911188);

            migrationBuilder.RenameColumn(
                name: "DisplayedRoleId",
                table: "Issues",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Issues_DisplayedRoleId",
                table: "Issues",
                newName: "IX_Issues_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "DisciplineTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 164385389, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1023), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1025), "Structured Cabling" },
                    { 184189092, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1090), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1091), "Energy Efficiency" },
                    { 290350167, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1143), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1145), "DWG Admin/Clearing" },
                    { 331354428, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(884), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(885), "HVAC" },
                    { 390116240, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1158), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1159), "Project Manager Hours" },
                    { 409266178, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(923), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(924), "Potable Water" },
                    { 482509020, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1050), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1051), "CCTV" },
                    { 501166454, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1064), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1065), "BMS" },
                    { 628937181, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1102), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1104), "Outsource" },
                    { 651723815, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(940), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(941), "Drainage" },
                    { 655146632, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(968), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(970), "Fire Suppression" },
                    { 669499730, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(982), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(983), "Elevators" },
                    { 687142022, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1077), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1078), "Photovoltaics" },
                    { 717305095, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(995), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(996), "Natural Gas" },
                    { 727931962, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(909), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(910), "Sewage" },
                    { 731022631, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1116), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1117), "TenderDocument" },
                    { 764445405, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(953), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(955), "Fire Detection" },
                    { 867770896, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1037), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1038), "Burglar Alarm" },
                    { 885615685, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1130), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1132), "Construction Supervision" },
                    { 951621683, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1009), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1010), "Power Distribution" }
                });

            migrationBuilder.InsertData(
                table: "DrawingTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 264194405, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1734), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1735), "Drawings" },
                    { 657063491, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1720), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1722), "Calculations" },
                    { 834534160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1700), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1701), "Documents" }
                });

            migrationBuilder.InsertData(
                table: "OtherTypes",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 207022497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3424), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3426), "Soft Copy" },
                    { 498609019, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3409), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3410), "Administration" },
                    { 716360954, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3379), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3380), "On-Site" },
                    { 722064785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3343), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3344), "Communications" },
                    { 724276678, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3364), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3365), "Printing" },
                    { 775558853, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3438), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3440), "Hours To Be Erased" },
                    { 852909449, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3392), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3393), "Meetings" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 130091889, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7248), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7249), "Dashboard Edit Other", 16 },
                    { 142482156, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7099), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7101), "Dashboard Add Project", 6 },
                    { 210009642, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7355), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7357), "See Active Delayed Project Types Counter KPI", 23 },
                    { 249695161, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7323), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7324), "See Employee Turnover KPI", 21 },
                    { 271958213, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7069), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7070), "Dashboard Assign Engineer", 4 },
                    { 357392399, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7279), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7280), "See Hours Per Role KPI", 18 },
                    { 377058179, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7131), "Dashboard See My Hours", 8 },
                    { 399056263, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7189), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7190), "Edit Project On Dashboard", 12 },
                    { 412283420, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7115), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7116), "See Admin Layout", 7 },
                    { 479578946, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7053), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7054), "Dashboard Assign Designer", 3 },
                    { 482303752, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7308), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7310), "See All Projects Missed DeadLine KPI", 20 },
                    { 502867731, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7035), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7036), "Dashboard Edit My Hours", 2 }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedDate", "LastUpdatedDate", "Name", "Ord" },
                values: new object[,]
                {
                    { 535075931, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7262), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7265), "Dashboard See KPIS", 17 },
                    { 604322297, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7160), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7161), "See All Drawings", 10 },
                    { 674379550, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7083), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7085), "Dashboard Assign Project Manager", 5 },
                    { 698742277, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7294), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7295), "See Active Delayed Projects KPI", 19 },
                    { 705377858, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7219), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7220), "Dashboard Edit Discipline", 14 },
                    { 710856637, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7175), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7176), "See All Projects", 11 },
                    { 837327415, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(6928), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(6930), "See Dashboard Layout", 1 },
                    { 854265727, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7144), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7146), "See All Disciplines", 9 },
                    { 859859026, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7203), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7205), "Display Projects Code", 13 },
                    { 876989901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7338), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7339), "See My Projects Missed DeadLine KPI", 22 },
                    { 877357391, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7233), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7234), "Dashboard Edit Deliverable", 15 }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "CanAssignePM", "CreatedDate", "Description", "LastUpdatedDate", "Name" },
                values: new object[,]
                {
                    { 188084384, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(263), "Infrastructure Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(264), "Infrastructure" },
                    { 423946154, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(240), "Buildings Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(242), "Buildings" },
                    { 751518333, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(292), "Consulting Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(293), "Consulting" },
                    { 797155677, false, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(310), "Production Management Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(311), "Production Management" },
                    { 961011244, true, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(277), "Energy Description", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(279), "Energy" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7514), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7515), "Admin", null },
                    { 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7372), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7373), "CEO", null },
                    { 822198159, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7485), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7486), "Guest", null },
                    { 871737531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7499), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7500), "Customer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "FirstName", "LastName", "LastUpdatedDate", "MidName", "Phone1", "Phone2", "Phone3", "ProjectId", "ProxyAddress", "TeamsObjectId" },
                values: new object[,]
                {
                    { 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9503), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΜΠΑΜΠΗΣ", "ΚΟΒΡΑΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9505), null, "694927778", null, null, null, "chkovras@embiria.onmicrosoft.com", null },
                    { 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(15), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΟΛΓΑ", "ΓΙΑΝΝΟΓΛΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(16), null, "694927778", null, null, null, "ogiannoglou@embiria.onmicrosoft.com", null },
                    { 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(195), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΟΛΑΟΣ", "ΤΡΙΑΝΤΑΦΥΛΛΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(197), null, "694927778", null, null, null, "ntriantafyllou@embiria.onmicrosoft.com", null },
                    { 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9582), "ΔΙΑΧΕΙΡΙΣΤΗΣ - ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΝΙΚΗΦΟΡΟΣ", "ΓΑΛΑΝΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9584), null, "694927778", null, null, null, "ngal@embiria.onmicrosoft.com", null },
                    { 396069851, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(372), "Admin", "Alexandros", "Platanios", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(373), null, "694927778", null, null, null, "empiriasoft@empiriasoftplat.onmicrosoft.com", null },
                    { 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9273), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΞΕΝΟΦΩΝ", "ΜΑΝΑΡΩΛΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9275), null, "694927778", null, null, null, "xmanarolis@embiria.onmicrosoft.com", null },
                    { 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(149), "ΜΗΧΑΝΙΚΟΣ ΤΕΙ - ΕΦΚΑ", "ΠΑΝΑΓΙΩΤΑ", "ΠΕΡΙΒΟΛΛΑΡΗ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(151), null, "694927778", null, null, null, "panperivollari@embiria.onmicrosoft.com", null },
                    { 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9429), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΣΤΕΦΑΝΟΣ", "ΠΑΡΙΣΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9430), null, "694927778", null, null, null, "sparisis@embiria.onmicrosoft.com", null },
                    { 530043390, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9127), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΜΑΝΩΛΗΣ", "ΧΑΤΖΑΚΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9129), null, "694927778", null, null, null, "mhatzakis@embiria.onmicrosoft.com", null },
                    { 590012631, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9056), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΔΗΜΗΤΡΗΣ", "ΤΣΑΛΑΜΑΓΚΑΚΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9058), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9783), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΣΙΛΕΙΟΣ", "ΤΖΑΝΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9784), null, "694927778", null, null, null, "vtza@embiria.onmicrosoft.com", null },
                    { 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9694), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΚΑΤΕΡΙΝΑ", "ΚΟΤΣΩΝΗ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9696), null, "694927778", null, null, null, "kkotsoni@embiria.onmicrosoft.com", null },
                    { 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(104), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΒΑΣΙΛΕΙΟΣ", "ΧΟΝΤΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(106), null, "694927778", null, null, null, "vchontos@embiria.onmicrosoft.com", null },
                    { 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9874), "ΜΗΧΑΝΙΚΟΣ - ΕΦΚΑ", "ΚΑΤΕΡΙΝΑ", "ΜΑΡΓΕΤΗ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9875), null, "694927778", null, null, null, "kmargeti@embiria.onmicrosoft.com", null },
                    { 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9919), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΧΑΡΗΣ", "ΠΛΑΤΑΝΙΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9920), null, "694927778", null, null, null, "haris@embiria.onmicrosoft.com", null },
                    { 825284728, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8834), "ΓΡΑΜΜΑΤΕΙΑ", "ΑΘΗΝΑ", "ΚΩΝΣΤΑΝΤΙΝΙΔΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8836), null, "694927778", null, null, null, "embiria@embiria.onmicrosoft.com", null },
                    { 835483227, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8965), "ΕΦΚΑ - ΣΧΕΔΙΑΣΤΗΣ", "ΓΡΗΓΟΡΗΣ", "ΔΟΥΓΑΛΕΡΗΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8967), null, "694927778", null, null, null, "dtsa@embiria.onmicrosoft.com", null },
                    { 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(59), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΒΑΡΒΑΡΑ", "ΛΕΚΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(61), null, "694927778", null, null, null, "blekou@embiria.onmicrosoft.com", null },
                    { 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9970), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΠΕΓΚΥ", "ΦΩΚΙΑΝΟΥ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9971), null, "694927778", null, null, null, "pfokianou@embiria.onmicrosoft.com", null },
                    { 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9199), "ΕΤΑΙΡΟΣ - ΜΗΧΑΝΙΚΟΣ - Τ.Π.Y.", "ΕΥΑΓΓΕΛΟΣ", "ΠΑΞΙΝΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9202), null, "694927778", null, null, null, "vpax@embiria.onmicrosoft.com", null },
                    { 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9828), "ΜΗΧΑΝΙΚΟΣ - Τ.Π.Υ.", "ΑΝΔΡΕΑΣ", "ΓΡΕΤΟΣ", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9830), null, "694927778", null, null, null, "agretos@embiria.onmicrosoft.com", null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "CreatedDate", "LastUpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 339226810, "ngal@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9612), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9615), 310844693 },
                    { 348259806, "gdoug@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8993), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8995), 835483227 },
                    { 414022111, "vtza@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9798), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9799), 604231330 },
                    { 428785915, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9084), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9086), 590012631 },
                    { 462665831, "ogiannoglou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(29), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(31), 221583835 },
                    { 478869674, "ntriantafyllou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(210), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(212), 222029997 },
                    { 480495823, "kkotsoni@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9721), 667465284 },
                    { 597598690, "empiriasoft@empiriasoftplat.onmicrosoft.com", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(387), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(388), 396069851 },
                    { 631486737, "kmargeti@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9891), 693577134 },
                    { 637049161, "pfokianou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9985), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9987), 989427526 },
                    { 643162329, "sparisis@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9452), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9454), 523335748 },
                    { 647500833, "dtsa@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9151), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9153), 530043390 },
                    { 685942768, "agretos@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9844), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9845), 997222832 },
                    { 724124329, "vchontos@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(119), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(121), 689402813 },
                    { 761469600, "blekou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(75), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(76), 980722489 },
                    { 797299087, "panperivollari@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(165), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(166), 481435429 },
                    { 821570621, "xmanarolis@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9381), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9383), 423324696 },
                    { 841051034, "embiria@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8871), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8873), 825284728 },
                    { 843479288, "vpax@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9225), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9227), 995610588 },
                    { 847734435, "akonstantinidou@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8906), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8909), 825284728 },
                    { 861757778, "haris@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9934), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9935), 804725668 },
                    { 989853979, "chkovras@embiria.gr", new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9529), new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9531), 159794805 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Active", "CalculationDaly", "Code", "Completed", "CreatedDate", "DeadLine", "Description", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "Fee", "LastUpdatedDate", "Name", "ProjectManagerId", "StartDate", "SubContractorId", "TypeId", "WorkPackegedCompleted" },
                values: new object[,]
                {
                    { 198329397, false, 1, "D-22-163", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 3, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_3", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_3", 995610588, new DateTime(2024, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 360899757, true, 2, "D-22-164", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_10", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_4", 667465284, new DateTime(2023, 12, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f },
                    { 547254174, true, 4, "D-22-164", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2025, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_4", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_4", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 751518333, 0f },
                    { 564441100, false, 1, "D-22-169", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 9, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_14", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_9", 995610588, new DateTime(2023, 2, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 658695706, true, 345, "D-22-16-PM", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 7, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_PM", 0f, 1500L, 12L, null, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_PM", null, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 797155677, 0f },
                    { 667712873, false, 1, "D-22-167", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 11, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_10", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_7", 667465284, new DateTime(2023, 6, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 682107086, false, 3, "D-22-165", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 1, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_6", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_5", 804725668, new DateTime(2023, 10, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 694095980, true, 4, "D-22-166", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 12, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_20", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_6", 995610588, new DateTime(2023, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 751518333, 0f },
                    { 749387009, false, 1, "D-22-161", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 5, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_5", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_1", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 423946154, 0f },
                    { 882693604, true, 2, "D-22-162", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2024, 8, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_4", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_2", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f },
                    { 887658868, false, 3, "D-22-163", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2025, 1, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_18", 0f, 1500L, 12L, 10000.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_3", 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 961011244, 0f },
                    { 905642845, true, 1, "D-22-168", 0f, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), new DateTime(2023, 10, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Test Description Project_36", 0f, 1500L, 12L, 1325.0, new DateTime(2024, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), "Project_Missed_DeadLine_8", 804725668, new DateTime(2023, 4, 3, 14, 44, 8, 310, DateTimeKind.Local).AddTicks(1833), null, 188084384, 0f }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 412283420, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8674), -1305652130, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8675) },
                    { 604322297, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8706), 760194527, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8707) },
                    { 710856637, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8721), 785047361, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8722) },
                    { 854265727, 290102901, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8689), 882743837, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8690) },
                    { 142482156, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8393), 1754683011, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8395) },
                    { 210009642, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8628), -363811085, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8629) },
                    { 249695161, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8612), 712464656, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8613) },
                    { 271958213, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8345), 1208850084, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8347) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 357392399, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8566), -1381845514, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8567) },
                    { 399056263, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8521), 1304261190, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8523) },
                    { 479578946, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8324), 605662250, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8326) },
                    { 482303752, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8597), -2097053801, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8598) },
                    { 502867731, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8302), -423880892, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8304) },
                    { 535075931, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8547), 1177069883, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8549) },
                    { 604322297, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8440), 1864093055, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8443) },
                    { 674379550, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8369), 397584532, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8371) },
                    { 698742277, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8581), -612792058, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8583) },
                    { 710856637, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8468), -1439005315, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8470) },
                    { 837327415, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8280), 166833064, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8282) },
                    { 854265727, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8416), -900380366, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8418) },
                    { 859859026, 532804602, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8495), 725686466, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8497) },
                    { 837327415, 822198159, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8643), 725156186, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8645) },
                    { 837327415, 871737531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8659), -1918373431, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8660) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7396), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7398), "COO", 532804602 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 532804602, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9667), 973571426, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9670) },
                    { 290102901, 396069851, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(401), 244861720, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(403) },
                    { 290102901, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(416), 308731576, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(417) }
                });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Completed", "CreatedDate", "EstimatedCompleted", "EstimatedHours", "EstimatedMandays", "LastUpdatedDate", "ProjectId", "TypeId", "UserId" },
                values: new object[,]
                {
                    { -2126765688, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1310), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1311), 887658868, 331354428, null },
                    { -2043627592, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1353), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1355), 547254174, 731022631, null },
                    { -2039382160, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1578), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1580), 667712873, 731022631, null },
                    { -2018807360, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1262), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1263), 882693604, 867770896, null },
                    { -1765060216, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1192), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1194), 749387009, 717305095, null },
                    { -1466298128, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1593), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1594), 905642845, 501166454, null },
                    { -1461728600, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1324), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1325), 887658868, 409266178, null },
                    { -1387564456, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1625), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1626), 905642845, 482509020, null },
                    { -1374660912, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1436), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1437), 360899757, 482509020, null },
                    { -1304128112, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1395), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1396), 198329397, 651723815, null },
                    { -1072777880, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1408), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1410), 198329397, 951621683, null },
                    { -1025676768, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1422), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1423), 360899757, 628937181, null },
                    { -1004363320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1367), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1368), 547254174, 727931962, null },
                    { -821294672, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1610), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1612), 905642845, 184189092, null },
                    { -766589960, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1232), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1233), 749387009, 764445405, null },
                    { -669688480, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1667), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1668), 564441100, 687142022, null },
                    { -13046320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1381), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1382), 198329397, 731022631, null },
                    { 48500184, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1494), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1495), 682107086, 331354428, null },
                    { 55276880, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1653), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1654), 564441100, 717305095, null },
                    { 761217232, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1639), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1640), 564441100, 867770896, null },
                    { 853549824, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1536), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1537), 694095980, 867770896, null },
                    { 858113144, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1452), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1453), 360899757, 717305095, null },
                    { 903388600, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1550), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1551), 667712873, 687142022, null },
                    { 1014884392, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1247), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1248), 882693604, 482509020, null },
                    { 1249013408, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1296), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1297), 887658868, 885615685, null },
                    { 1338483552, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1218), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1219), 749387009, 731022631, null },
                    { 1476244320, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1480), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1482), 682107086, 731022631, null },
                    { 1514478272, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1466), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1468), 682107086, 628937181, null },
                    { 1735143456, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1277), 0f, 416L, 52L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1279), 882693604, 501166454, null },
                    { 1786998136, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1339), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1341), 547254174, 885615685, null },
                    { 1922016840, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1564), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1565), 667712873, 482509020, null },
                    { 1961561656, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1508), 0f, 400L, 50L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1510), 694095980, 727931962, null },
                    { 2058347776, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1522), 0f, 408L, 51L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1524), 694095980, 655146632, null },
                    { 2091716744, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1682), 0f, 500L, 0L, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1683), 658695706, 390116240, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 146696663, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(803), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(806), 103000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(805), "Signature 1423425", 81416, 667712873, 5.0, 17.0 },
                    { 380678347, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(714), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(716), 3100.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(715), "Signature 142346", 64709, 360899757, 2.0, 24.0 },
                    { 422248645, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(589), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(591), 4000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(590), "Signature 142343", 49829, 887658868, 3.0, 17.0 },
                    { 444653229, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(833), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(836), 1003000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(834), "Signature 1423430", 74720, 905642845, 6.0, 24.0 },
                    { 467307575, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(506), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(509), 3010.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(507), "Signature 142345", 34954, 749387009, 1.0, 17.0 },
                    { 513310416, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(554), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(556), 3100.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(555), "Signature 1423410", 39512, 882693604, 2.0, 24.0 },
                    { 603505183, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(744), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(747), 4000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(745), "Signature 1423415", 20947, 682107086, 3.0, 17.0 },
                    { 694633497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(774), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(777), 13000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(775), "Signature 142348", 57542, 694095980, 4.0, 24.0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "Date", "Fee", "LastUpdatedDate", "Mark", "Number", "ProjectId", "Total", "Vat" },
                values: new object[,]
                {
                    { 749276467, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(862), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(865), 10003000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(864), "Signature 1423414", 78590, 564441100, 7.0, 17.0 },
                    { 910211743, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(619), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(622), 13000.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(621), "Signature 142348", 11157, 547254174, 4.0, 24.0 },
                    { 978781555, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(679), new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(682), 3010.0, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(680), "Signature 142346", 26783, 198329397, 1.0, 17.0 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 271958213, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7872), -1189180151, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7874) },
                    { 377058179, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7903), -2122727129, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7904) },
                    { 479578946, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7856), -1355621008, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7857) },
                    { 502867731, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7841), -246021506, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7842) },
                    { 604322297, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7933), 1125439061, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7935) },
                    { 674379550, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7888), -1083012268, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7889) },
                    { 710856637, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7949), 1792343790, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7950) },
                    { 837327415, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7826), -170748742, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7827) },
                    { 854265727, 692744033, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7918), -183194027, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7919) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7411), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7412), "CTO", 692744033 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 692744033, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9753), 543913233, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9755) });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2126765688, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8416), 191833669, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8417) },
                    { -2126765688, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8526), 799449099, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8527) },
                    { -2126765688, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8581), 517121614, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8583) },
                    { -2126765688, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8430), 249431689, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8431) },
                    { -2126765688, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8385), 362884497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8386) },
                    { -2126765688, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8567), 166419031, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8569) },
                    { -2126765688, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8398), 438613537, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8400) },
                    { -2126765688, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8458), 767513509, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8459) },
                    { -2126765688, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8444), 965517265, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8445) },
                    { -2126765688, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8553), 493780500, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8555) },
                    { -2126765688, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8485), 781410009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8486) },
                    { -2126765688, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8499), 694196502, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8500) },
                    { -2126765688, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8540), 433617525, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8541) },
                    { -2126765688, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8512), 429488598, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8514) },
                    { -2126765688, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8371), 961276025, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8373) },
                    { -2126765688, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8471), 927403803, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8472) },
                    { -2043627592, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9129), 673107828, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9131) },
                    { -2043627592, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9242), 215955371, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9243) },
                    { -2043627592, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9297), 575641429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9298) },
                    { -2043627592, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9143), 923287453, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9144) },
                    { -2043627592, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9102), 628070861, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9104) },
                    { -2043627592, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9283), 448731189, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9284) },
                    { -2043627592, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9116), 622057938, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9117) },
                    { -2043627592, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9170), 766183762, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9171) },
                    { -2043627592, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9156), 161343063, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9157) },
                    { -2043627592, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9269), 669475397, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9271) },
                    { -2043627592, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9198), 134692638, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9199) },
                    { -2043627592, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9215), 308954316, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9216) },
                    { -2043627592, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9256), 127528433, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9257) },
                    { -2043627592, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9229), 279876497, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9230) },
                    { -2043627592, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9089), 337465411, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9090) },
                    { -2043627592, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9184), 190960429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9185) },
                    { -2039382160, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2706), 392205745, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2708) },
                    { -2039382160, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2827), 977514955, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2828) },
                    { -2039382160, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2886), 508123705, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2888) },
                    { -2039382160, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2720), 389739181, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2721) },
                    { -2039382160, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2679), 683763831, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2680) },
                    { -2039382160, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2868), 876347052, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2869) },
                    { -2039382160, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2692), 595215093, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2694) },
                    { -2039382160, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2760), 743597023, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2761) },
                    { -2039382160, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2747), 343296125, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2748) },
                    { -2039382160, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2854), 460330700, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2855) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -2039382160, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2787), 909266853, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2788) },
                    { -2039382160, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2800), 403898136, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2802) },
                    { -2039382160, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2840), 444829017, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2842) },
                    { -2039382160, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2814), 635451291, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2815) },
                    { -2039382160, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2665), 325279538, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2666) },
                    { -2039382160, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2774), 768113359, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2775) },
                    { -2018807360, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7753), 960645466, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7754) },
                    { -2018807360, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7863), 288952942, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7864) },
                    { -2018807360, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7917), 600304234, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7919) },
                    { -2018807360, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7766), 231328729, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7768) },
                    { -2018807360, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7726), 939868974, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7727) },
                    { -2018807360, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7904), 517234666, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7905) },
                    { -2018807360, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7740), 338114435, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7741) },
                    { -2018807360, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7794), 811415681, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7795) },
                    { -2018807360, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7780), 536998742, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7782) },
                    { -2018807360, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7890), 948227671, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7891) },
                    { -2018807360, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7821), 682984176, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7823) },
                    { -2018807360, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7836), 150418441, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7837) },
                    { -2018807360, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7876), 527215027, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7878) },
                    { -2018807360, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7849), 244632067, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7850) },
                    { -2018807360, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7711), 948377260, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7713) },
                    { -2018807360, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7808), 393269274, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7809) },
                    { -1765060216, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6865), 997410370, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6867) },
                    { -1765060216, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6978), 418750600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6979) },
                    { -1765060216, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7032), 820576933, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7034) },
                    { -1765060216, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6879), 904990428, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6880) },
                    { -1765060216, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6838), 787113164, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6839) },
                    { -1765060216, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7018), 234045912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7020) },
                    { -1765060216, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6852), 922222088, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6853) },
                    { -1765060216, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6907), 358071669, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6908) },
                    { -1765060216, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6893), 250473566, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6895) },
                    { -1765060216, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7005), 218208110, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7006) },
                    { -1765060216, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6934), 447867930, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6935) },
                    { -1765060216, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6948), 318378699, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6950) },
                    { -1765060216, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6991), 691464607, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6993) },
                    { -1765060216, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6962), 202071200, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6964) },
                    { -1765060216, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6813), 157474850, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6815) },
                    { -1765060216, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6920), 751648719, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6922) },
                    { -1466298128, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2942), 660327090, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2943) },
                    { -1466298128, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3062), 852304353, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3063) },
                    { -1466298128, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3114), 736004042, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3115) },
                    { -1466298128, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2955), 764644757, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2956) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1466298128, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2915), 636719313, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2916) },
                    { -1466298128, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3101), 726032683, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3102) },
                    { -1466298128, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2928), 975188951, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2929) },
                    { -1466298128, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2982), 306488295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2983) },
                    { -1466298128, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2968), 581289605, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2970) },
                    { -1466298128, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3088), 540094299, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3089) },
                    { -1466298128, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3009), 771594491, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3010) },
                    { -1466298128, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3022), 983278535, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3024) },
                    { -1466298128, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3075), 371522987, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3076) },
                    { -1466298128, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3049), 780208056, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3050) },
                    { -1466298128, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2900), 919563755, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2902) },
                    { -1466298128, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2995), 681556038, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2997) },
                    { -1461728600, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8636), 533063285, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8638) },
                    { -1461728600, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8800), 940437042, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8802) },
                    { -1461728600, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8855), 490958204, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8857) },
                    { -1461728600, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8650), 880081095, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8651) },
                    { -1461728600, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8609), 296095516, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8611) },
                    { -1461728600, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8842), 992693018, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8843) },
                    { -1461728600, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8623), 197470819, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8624) },
                    { -1461728600, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8677), 927977569, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8678) },
                    { -1461728600, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8663), 267960297, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8665) },
                    { -1461728600, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8828), 204958009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8829) },
                    { -1461728600, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8704), 228678634, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8706) },
                    { -1461728600, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8767), 702807067, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8769) },
                    { -1461728600, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8814), 571323323, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8816) },
                    { -1461728600, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8787), 217832847, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8788) },
                    { -1461728600, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8595), 423801066, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8596) },
                    { -1461728600, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8690), 916594527, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8692) },
                    { -1387564456, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3382), 792634378, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3383) },
                    { -1387564456, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3487), 930132625, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3488) },
                    { -1387564456, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3539), 132674392, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3540) },
                    { -1387564456, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3395), 311884763, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3396) },
                    { -1387564456, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3356), 307607887, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3357) },
                    { -1387564456, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3526), 934794164, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3527) },
                    { -1387564456, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3369), 997531758, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3370) },
                    { -1387564456, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3421), 513855163, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3423) },
                    { -1387564456, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3408), 439416748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3410) },
                    { -1387564456, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3513), 237979438, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3514) },
                    { -1387564456, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3447), 606993764, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3449) },
                    { -1387564456, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3461), 643848200, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3462) },
                    { -1387564456, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3500), 316432661, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3501) },
                    { -1387564456, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3474), 525160549, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3475) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1387564456, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3342), 322110376, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3343) },
                    { -1387564456, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3434), 511147639, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3436) },
                    { -1374660912, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(452), 875603473, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(453) },
                    { -1374660912, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(559), 250332015, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(561) },
                    { -1374660912, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(613), 570899236, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(615) },
                    { -1374660912, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(465), 186221258, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(467) },
                    { -1374660912, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(425), 766735897, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(426) },
                    { -1374660912, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(600), 204103268, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(601) },
                    { -1374660912, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(438), 866127864, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(440) },
                    { -1374660912, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(492), 288066636, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(493) },
                    { -1374660912, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(479), 856394041, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(480) },
                    { -1374660912, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(586), 729221136, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(588) },
                    { -1374660912, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(519), 823111945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(520) },
                    { -1374660912, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(532), 557657693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(534) },
                    { -1374660912, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(573), 670810594, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(574) },
                    { -1374660912, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(546), 201705391, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(547) },
                    { -1374660912, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(407), 536509644, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(408) },
                    { -1374660912, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(505), 268617777, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(507) },
                    { -1304128112, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9791), 227670356, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9792) },
                    { -1304128112, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9901), 470426329, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9902) },
                    { -1304128112, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9955), 940421358, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9956) },
                    { -1304128112, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9804), 396698974, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9806) },
                    { -1304128112, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9763), 191810991, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9765) },
                    { -1304128112, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9942), 518298764, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9943) },
                    { -1304128112, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9777), 817077441, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9778) },
                    { -1304128112, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9832), 479011780, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9833) },
                    { -1304128112, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9818), 261306514, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9819) },
                    { -1304128112, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9928), 961284592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9929) },
                    { -1304128112, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9859), 378752760, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9860) },
                    { -1304128112, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9873), 916368874, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9875) },
                    { -1304128112, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9914), 677015087, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9916) },
                    { -1304128112, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9887), 687462373, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9888) },
                    { -1304128112, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9750), 702740612, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9751) },
                    { -1304128112, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9845), 807030145, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9847) },
                    { -1072777880, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(10), 984533269, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(11) },
                    { -1072777880, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(124), 144555584, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(126) },
                    { -1072777880, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(177), 993878137, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(179) },
                    { -1072777880, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(23), 510703754, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(25) },
                    { -1072777880, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9983), 373265313, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9984) },
                    { -1072777880, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(164), 245144421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(165) },
                    { -1072777880, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9996), 571446493, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9998) },
                    { -1072777880, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(54), 562880411, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(55) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -1072777880, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(37), 259799705, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(38) },
                    { -1072777880, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(151), 848805657, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(152) },
                    { -1072777880, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(84), 499678566, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(85) },
                    { -1072777880, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(97), 834208772, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(99) },
                    { -1072777880, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(137), 204669500, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(139) },
                    { -1072777880, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(111), 434468982, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(112) },
                    { -1072777880, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9969), 228540616, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9970) },
                    { -1072777880, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(70), 337752888, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(71) },
                    { -1025676768, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(233), 934556782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(234) },
                    { -1025676768, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(340), 270627528, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(341) },
                    { -1025676768, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(393), 802706892, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(394) },
                    { -1025676768, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(246), 867395295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(247) },
                    { -1025676768, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(205), 238346610, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(206) },
                    { -1025676768, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(380), 763320303, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(381) },
                    { -1025676768, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(219), 759945833, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(220) },
                    { -1025676768, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(273), 921987970, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(274) },
                    { -1025676768, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(259), 785248801, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(261) },
                    { -1025676768, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(367), 199324890, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(368) },
                    { -1025676768, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(300), 716071325, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(301) },
                    { -1025676768, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(313), 260054352, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(314) },
                    { -1025676768, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(353), 889110274, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(354) },
                    { -1025676768, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(326), 358241036, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(328) },
                    { -1025676768, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(191), 444968362, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(192) },
                    { -1025676768, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(286), 205179350, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(288) },
                    { -1004363320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9351), 245312995, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9352) },
                    { -1004363320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9459), 700963837, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9461) },
                    { -1004363320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9513), 386896261, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9515) },
                    { -1004363320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9365), 773715190, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9366) },
                    { -1004363320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9324), 723514253, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9325) },
                    { -1004363320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9500), 978039626, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9501) },
                    { -1004363320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9338), 950409027, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9339) },
                    { -1004363320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9392), 510841284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9393) },
                    { -1004363320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9378), 157265759, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9379) },
                    { -1004363320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9486), 380028612, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9488) },
                    { -1004363320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9418), 967103507, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9420) },
                    { -1004363320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9432), 603007105, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9433) },
                    { -1004363320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9473), 477284622, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9474) },
                    { -1004363320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9446), 138586754, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9447) },
                    { -1004363320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9310), 246101032, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9312) },
                    { -1004363320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9405), 305653009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9406) },
                    { -821294672, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3167), 231023498, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3168) },
                    { -821294672, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3272), 472752979, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3273) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -821294672, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3328), 476672123, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3329) },
                    { -821294672, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3180), 580408460, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3182) },
                    { -821294672, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3141), 734463800, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3143) },
                    { -821294672, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3315), 810425828, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3316) },
                    { -821294672, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3154), 607120993, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3156) },
                    { -821294672, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3206), 482376137, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3208) },
                    { -821294672, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3193), 376986429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3195) },
                    { -821294672, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3298), 306083665, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3300) },
                    { -821294672, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3233), 345702151, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3234) },
                    { -821294672, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3246), 443341989, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3247) },
                    { -821294672, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3285), 383803327, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3287) },
                    { -821294672, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3259), 899903279, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3260) },
                    { -821294672, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3128), 930466672, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3129) },
                    { -821294672, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3220), 266707222, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3221) },
                    { -766589960, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7311), 591479261, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7312) },
                    { -766589960, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7421), 593341423, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7422) },
                    { -766589960, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7475), 786683585, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7477) },
                    { -766589960, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7325), 460100054, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7326) },
                    { -766589960, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7284), 798593618, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7285) },
                    { -766589960, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7461), 380873041, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7463) },
                    { -766589960, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7297), 854142770, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7299) },
                    { -766589960, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7352), 895980251, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7354) },
                    { -766589960, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7339), 430908431, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7340) },
                    { -766589960, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7448), 735624777, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7449) },
                    { -766589960, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7380), 923235503, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7381) },
                    { -766589960, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7393), 983015216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7394) },
                    { -766589960, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7434), 579976911, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7435) },
                    { -766589960, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7407), 898817736, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7408) },
                    { -766589960, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7269), 619535616, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7271) },
                    { -766589960, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7366), 393484258, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7367) },
                    { -669688480, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4025), 718003533, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4026) },
                    { -669688480, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4130), 541239155, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4131) },
                    { -669688480, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4186), 570743561, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4187) },
                    { -669688480, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4038), 887048780, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4039) },
                    { -669688480, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3998), 686333810, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3999) },
                    { -669688480, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4173), 448637605, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4174) },
                    { -669688480, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4011), 698198553, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4012) },
                    { -669688480, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4064), 154684076, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4065) },
                    { -669688480, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4051), 209784791, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4052) },
                    { -669688480, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4159), 743268421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4161) },
                    { -669688480, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4090), 292410715, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4092) },
                    { -669688480, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4104), 507377133, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4105) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { -669688480, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4146), 934966150, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4147) },
                    { -669688480, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4117), 981294653, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4118) },
                    { -669688480, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3979), 722828470, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3980) },
                    { -669688480, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4077), 487006524, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(4078) },
                    { -13046320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9568), 259135582, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9570) },
                    { -13046320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9681), 186866251, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9683) },
                    { -13046320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9736), 906152324, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9738) },
                    { -13046320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9582), 242452382, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9583) },
                    { -13046320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9541), 733668310, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9542) },
                    { -13046320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9723), 402047453, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9724) },
                    { -13046320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9555), 721734554, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9556) },
                    { -13046320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9609), 534468562, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9611) },
                    { -13046320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9595), 452454756, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9597) },
                    { -13046320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9709), 275962409, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9710) },
                    { -13046320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9640), 524669281, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9642) },
                    { -13046320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9654), 556030090, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9655) },
                    { -13046320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9695), 422003585, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9697) },
                    { -13046320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9668), 422800842, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9669) },
                    { -13046320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9527), 517817817, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9528) },
                    { -13046320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9623), 398234551, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9624) },
                    { 48500184, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1326), 752672115, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1328) },
                    { 48500184, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1434), 495817267, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1436) },
                    { 48500184, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1488), 339598917, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1489) },
                    { 48500184, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1340), 583964093, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1341) },
                    { 48500184, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1299), 913683224, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1301) },
                    { 48500184, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1475), 442025486, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1476) },
                    { 48500184, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1313), 915981737, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1314) },
                    { 48500184, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1367), 928551773, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1368) },
                    { 48500184, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1353), 433855919, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1355) },
                    { 48500184, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1461), 133434342, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1462) },
                    { 48500184, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1394), 550346407, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1395) },
                    { 48500184, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1407), 848559115, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1409) },
                    { 48500184, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1448), 578999851, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1449) },
                    { 48500184, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1421), 841400224, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1422) },
                    { 48500184, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1286), 851529399, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1287) },
                    { 48500184, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1380), 145309695, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1382) },
                    { 55276880, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3807), 911190400, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3808) },
                    { 55276880, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3912), 562589477, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3914) },
                    { 55276880, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3965), 716643490, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3966) },
                    { 55276880, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3820), 421897634, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3821) },
                    { 55276880, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3781), 684350295, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3782) },
                    { 55276880, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3952), 326418245, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3953) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 55276880, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3794), 959633372, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3795) },
                    { 55276880, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3847), 954411469, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3848) },
                    { 55276880, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3833), 237083837, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3835) },
                    { 55276880, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3939), 980337712, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3940) },
                    { 55276880, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3873), 739304200, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3875) },
                    { 55276880, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3886), 334432709, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3887) },
                    { 55276880, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3926), 248098462, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3927) },
                    { 55276880, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3899), 274933475, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3901) },
                    { 55276880, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3768), 806953735, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3769) },
                    { 55276880, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3860), 157066438, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3861) },
                    { 761217232, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3591), 918675366, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3593) },
                    { 761217232, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3697), 726238855, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3699) },
                    { 761217232, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3754), 697639354, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3755) },
                    { 761217232, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3605), 535742816, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3606) },
                    { 761217232, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3565), 195323095, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3567) },
                    { 761217232, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3741), 568328228, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3742) },
                    { 761217232, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3578), 705718876, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3580) },
                    { 761217232, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3632), 394828058, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3633) },
                    { 761217232, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3619), 604966802, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3620) },
                    { 761217232, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3727), 479597960, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3728) },
                    { 761217232, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3658), 955983293, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3659) },
                    { 761217232, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3671), 505379500, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3673) },
                    { 761217232, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3711), 794912940, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3712) },
                    { 761217232, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3684), 296896675, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3686) },
                    { 761217232, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3552), 268116057, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3554) },
                    { 761217232, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3645), 912898057, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(3646) },
                    { 853549824, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2042), 685076935, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2043) },
                    { 853549824, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2152), 692543338, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2154) },
                    { 853549824, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2207), 216185739, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2208) },
                    { 853549824, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2056), 249266717, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2057) },
                    { 853549824, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2010), 162737631, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2011) },
                    { 853549824, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2193), 634967945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2195) },
                    { 853549824, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2028), 881252761, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2029) },
                    { 853549824, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2084), 233573439, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2085) },
                    { 853549824, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2070), 762616719, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2071) },
                    { 853549824, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2180), 343429817, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2181) },
                    { 853549824, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2112), 600312692, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2113) },
                    { 853549824, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2125), 255207986, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2126) },
                    { 853549824, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2166), 228287637, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2167) },
                    { 853549824, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2139), 822150130, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2140) },
                    { 853549824, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1996), 837384798, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1997) },
                    { 853549824, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2098), 405204031, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2099) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 858113144, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(667), 920637398, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(669) },
                    { 858113144, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(778), 611861761, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(780) },
                    { 858113144, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(833), 701507392, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(834) },
                    { 858113144, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(681), 695273302, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(682) },
                    { 858113144, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(640), 391247924, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(642) },
                    { 858113144, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(819), 468389065, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(821) },
                    { 858113144, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(654), 315019082, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(655) },
                    { 858113144, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(711), 353995030, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(712) },
                    { 858113144, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(697), 962225044, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(698) },
                    { 858113144, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(806), 926788162, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(807) },
                    { 858113144, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(738), 836716436, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(739) },
                    { 858113144, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(751), 939498009, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(753) },
                    { 858113144, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(792), 379637870, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(793) },
                    { 858113144, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(765), 618234908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(766) },
                    { 858113144, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(627), 384353842, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(628) },
                    { 858113144, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(724), 392191570, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(726) },
                    { 903388600, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2262), 996285064, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2263) },
                    { 903388600, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2372), 945909765, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2373) },
                    { 903388600, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2427), 864147538, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2428) },
                    { 903388600, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2276), 458026091, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2277) },
                    { 903388600, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2234), 363200617, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2236) },
                    { 903388600, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2413), 595976074, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2414) },
                    { 903388600, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2248), 236534567, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2249) },
                    { 903388600, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2303), 500587565, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2304) },
                    { 903388600, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2289), 137351644, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2291) },
                    { 903388600, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2399), 588137404, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2401) },
                    { 903388600, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2331), 758601383, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2332) },
                    { 903388600, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2344), 675177592, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2346) },
                    { 903388600, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2386), 227722953, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2387) },
                    { 903388600, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2358), 125279315, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2359) },
                    { 903388600, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2221), 296185213, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2222) },
                    { 903388600, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2316), 314393972, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2318) },
                    { 1014884392, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7530), 919353632, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7531) },
                    { 1014884392, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7643), 274517080, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7644) },
                    { 1014884392, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7698), 606526240, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7699) },
                    { 1014884392, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7543), 930254369, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7545) },
                    { 1014884392, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7502), 648644156, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7504) },
                    { 1014884392, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7684), 614230217, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7685) },
                    { 1014884392, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7516), 327051785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7517) },
                    { 1014884392, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7571), 185793595, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7572) },
                    { 1014884392, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7557), 721647111, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7558) },
                    { 1014884392, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7670), 733700388, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7672) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1014884392, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7598), 836264403, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7600) },
                    { 1014884392, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7615), 763873440, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7617) },
                    { 1014884392, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7657), 953998567, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7658) },
                    { 1014884392, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7630), 490746864, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7631) },
                    { 1014884392, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7489), 322757009, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7490) },
                    { 1014884392, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7585), 511415976, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7586) },
                    { 1249013408, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8194), 443832636, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8195) },
                    { 1249013408, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8302), 286847410, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8303) },
                    { 1249013408, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8358), 927364989, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8359) },
                    { 1249013408, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8207), 139521992, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8208) },
                    { 1249013408, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8166), 952573830, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8167) },
                    { 1249013408, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8343), 914890852, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8345) },
                    { 1249013408, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8180), 505549618, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8181) },
                    { 1249013408, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8234), 410136393, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8236) },
                    { 1249013408, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8221), 792301735, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8222) },
                    { 1249013408, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8330), 703627544, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8331) },
                    { 1249013408, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8261), 270479392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8263) },
                    { 1249013408, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8275), 311251764, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8276) },
                    { 1249013408, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8316), 210196172, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8317) },
                    { 1249013408, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8288), 838218245, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8290) },
                    { 1249013408, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8152), 802214206, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8154) },
                    { 1249013408, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8248), 802373307, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8249) },
                    { 1338483552, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7089), 659709600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7090) },
                    { 1338483552, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7198), 836641227, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7199) },
                    { 1338483552, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7256), 142212362, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7257) },
                    { 1338483552, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7102), 950456154, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7104) },
                    { 1338483552, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7061), 405138564, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7062) },
                    { 1338483552, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7242), 471639006, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7243) },
                    { 1338483552, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7075), 515673644, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7076) },
                    { 1338483552, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7130), 327468463, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7131) },
                    { 1338483552, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7116), 294931716, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7118) },
                    { 1338483552, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7229), 651368708, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7230) },
                    { 1338483552, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7157), 513028312, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7158) },
                    { 1338483552, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7171), 657725993, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7172) },
                    { 1338483552, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7215), 834599650, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7216) },
                    { 1338483552, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7185), 348406940, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7186) },
                    { 1338483552, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7046), 293422701, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7047) },
                    { 1338483552, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7143), 272622492, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7145) },
                    { 1476244320, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1104), 937721119, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1105) },
                    { 1476244320, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1218), 754961908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1220) },
                    { 1476244320, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1272), 254540183, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1274) },
                    { 1476244320, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1122), 280613632, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1123) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1476244320, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1077), 593178666, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1078) },
                    { 1476244320, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1259), 150208835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1260) },
                    { 1476244320, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1090), 171927549, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1092) },
                    { 1476244320, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1149), 417198771, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1151) },
                    { 1476244320, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1135), 996499580, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1137) },
                    { 1476244320, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1245), 891994853, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1246) },
                    { 1476244320, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1177), 440911271, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1178) },
                    { 1476244320, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1190), 584092100, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1191) },
                    { 1476244320, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1232), 861985088, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1233) },
                    { 1476244320, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1205), 549415747, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1206) },
                    { 1476244320, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1063), 330835784, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1065) },
                    { 1476244320, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1163), 867532972, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1164) },
                    { 1514478272, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(887), 805704415, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(888) },
                    { 1514478272, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(995), 873456227, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(996) },
                    { 1514478272, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1049), 327097051, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1051) },
                    { 1514478272, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(901), 479749911, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(902) },
                    { 1514478272, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(860), 449727897, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(861) },
                    { 1514478272, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1036), 418580951, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1037) },
                    { 1514478272, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(873), 189632848, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(875) },
                    { 1514478272, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(927), 682769908, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(929) },
                    { 1514478272, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(914), 728261357, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(915) },
                    { 1514478272, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1022), 467115441, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1023) },
                    { 1514478272, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(955), 904940582, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(956) },
                    { 1514478272, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(968), 496236945, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(970) },
                    { 1514478272, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1008), 447295932, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1010) },
                    { 1514478272, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(982), 695059693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(983) },
                    { 1514478272, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(847), 572940984, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(848) },
                    { 1514478272, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(941), 638573336, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(942) },
                    { 1735143456, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7972), 728002564, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7973) },
                    { 1735143456, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8085), 150284988, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8086) },
                    { 1735143456, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8139), 992785902, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8140) },
                    { 1735143456, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7988), 840546175, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7990) },
                    { 1735143456, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7945), 799186892, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7946) },
                    { 1735143456, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8125), 954400821, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8127) },
                    { 1735143456, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7958), 975191131, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7959) },
                    { 1735143456, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8016), 293588158, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8017) },
                    { 1735143456, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8002), 330789496, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8004) },
                    { 1735143456, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8112), 947359050, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8113) },
                    { 1735143456, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8044), 933419051, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8045) },
                    { 1735143456, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8057), 906921565, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8059) },
                    { 1735143456, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8098), 458374927, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8100) },
                    { 1735143456, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8071), 332689239, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8072) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1735143456, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7931), 987884353, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(7932) },
                    { 1735143456, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8030), 569488939, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8031) },
                    { 1786998136, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8910), 823027596, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8912) },
                    { 1786998136, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9021), 937701026, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9022) },
                    { 1786998136, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9075), 412310641, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9076) },
                    { 1786998136, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8924), 215853539, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8925) },
                    { 1786998136, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8883), 381811642, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8884) },
                    { 1786998136, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9061), 402626909, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9063) },
                    { 1786998136, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8897), 865708115, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8898) },
                    { 1786998136, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8951), 619671873, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8953) },
                    { 1786998136, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8938), 253811483, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8939) },
                    { 1786998136, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9048), 820348905, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9049) },
                    { 1786998136, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8979), 736516707, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8980) },
                    { 1786998136, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8993), 137676242, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8994) },
                    { 1786998136, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9034), 593276645, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9035) },
                    { 1786998136, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9007), 773343990, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(9008) },
                    { 1786998136, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8869), 796622624, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8871) },
                    { 1786998136, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8965), 196980893, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(8966) },
                    { 1922016840, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2486), 789782069, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2487) },
                    { 1922016840, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2596), 849378798, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2597) },
                    { 1922016840, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2651), 362358582, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2652) },
                    { 1922016840, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2500), 764623009, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2501) },
                    { 1922016840, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2458), 807667764, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2460) },
                    { 1922016840, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2637), 950149866, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2638) },
                    { 1922016840, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2472), 364734621, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2473) },
                    { 1922016840, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2527), 605153400, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2529) },
                    { 1922016840, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2514), 142104119, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2515) },
                    { 1922016840, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2623), 471583675, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2625) },
                    { 1922016840, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2555), 847649601, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2556) },
                    { 1922016840, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2569), 172682383, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2570) },
                    { 1922016840, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2610), 551081649, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2611) },
                    { 1922016840, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2582), 846804873, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2584) },
                    { 1922016840, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2441), 601274040, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2442) },
                    { 1922016840, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2541), 841551736, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(2543) },
                    { 1961561656, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1546), 902265386, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1547) },
                    { 1961561656, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1653), 174689236, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1654) },
                    { 1961561656, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1707), 257743318, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1708) },
                    { 1961561656, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1559), 709353008, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1560) },
                    { 1961561656, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1515), 734069270, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1516) },
                    { 1961561656, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1693), 168431305, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1695) },
                    { 1961561656, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1528), 719159230, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1530) },
                    { 1961561656, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1586), 828398660, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1587) }
                });

            migrationBuilder.InsertData(
                table: "DisciplineEngineer",
                columns: new[] { "DisciplineId", "EngineerId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 1961561656, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1573), 720286561, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1574) },
                    { 1961561656, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1680), 868698604, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1681) },
                    { 1961561656, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1612), 935733328, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1614) },
                    { 1961561656, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1626), 636249782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1627) },
                    { 1961561656, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1666), 254561564, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1668) },
                    { 1961561656, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1639), 958674371, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1641) },
                    { 1961561656, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1501), 796985922, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1503) },
                    { 1961561656, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1599), 713472430, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1600) },
                    { 2058347776, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1761), 880332138, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1762) },
                    { 2058347776, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1924), 133048343, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1925) },
                    { 2058347776, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1981), 566222643, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1982) },
                    { 2058347776, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1774), 365916309, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1776) },
                    { 2058347776, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1734), 292885179, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1735) },
                    { 2058347776, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1967), 425072832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1968) },
                    { 2058347776, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1747), 429752391, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1749) },
                    { 2058347776, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1802), 326150968, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1803) },
                    { 2058347776, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1788), 273564298, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1790) },
                    { 2058347776, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1953), 127973782, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1954) },
                    { 2058347776, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1829), 293778410, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1830) },
                    { 2058347776, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1893), 873909572, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1894) },
                    { 2058347776, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1938), 351688421, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1939) },
                    { 2058347776, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1909), 667896793, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1911) },
                    { 2058347776, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1720), 863804242, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1722) },
                    { 2058347776, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1815), 609876556, new DateTime(2024, 4, 3, 14, 44, 8, 326, DateTimeKind.Local).AddTicks(1817) }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 139389886, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1823), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1820), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1821), 657063491 },
                    { 141863418, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2439), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2436), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2437), 834534160 },
                    { 144940712, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3167), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3164), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3165), 834534160 },
                    { 144996997, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2590), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2587), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2589), 834534160 },
                    { 145438318, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2050), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2047), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2048), 657063491 },
                    { 165748714, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2182), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2179), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2181), 657063491 },
                    { 166806025, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1756), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1751), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1753), 834534160 },
                    { 188641697, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3282), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3279), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3281), 264194405 },
                    { 195394316, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1960), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1958), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1959), 657063491 },
                    { 196765683, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2620), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2617), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2618), 264194405 },
                    { 233393383, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3123), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3121), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3122), 834534160 },
                    { 238070596, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2240), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2237), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2239), 264194405 },
                    { 245985170, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2874), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2871), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2872), 657063491 },
                    { 286584383, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2321), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2318), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2320), 657063491 },
                    { 324109566, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2917), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2914), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2915), 657063491 },
                    { 330135627, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2335), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2333), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2334), 264194405 },
                    { 331994708, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3023), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3020), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3021), 264194405 },
                    { 346958205, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2664), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2661), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2662), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 351105458, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2816), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2813), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2814), 834534160 },
                    { 365873516, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2605), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2602), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2604), 657063491 },
                    { 366107512, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2079), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2076), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2078), 834534160 },
                    { 382780665, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2152), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2150), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2151), 264194405 },
                    { 401097784, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3066), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3063), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3064), 264194405 },
                    { 410989400, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2004), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2001), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2003), 657063491 },
                    { 415458283, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2379), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2376), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2378), 264194405 },
                    { 430225625, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2395), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2392), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2393), 834534160 },
                    { 433650873, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3328), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3325), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3326), 264194405 },
                    { 445716980, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1868), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1865), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1867), 657063491 },
                    { 449122456, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2290), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2287), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2288), 264194405 },
                    { 452435566, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2830), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2827), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2829), 657063491 },
                    { 458648265, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2365), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2362), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2363), 657063491 },
                    { 466067187, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3080), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3077), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3079), 834534160 },
                    { 471993376, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2306), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2303), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2305), 834534160 },
                    { 483098671, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3195), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3193), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3194), 264194405 },
                    { 492471635, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1931), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1929), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1930), 264194405 },
                    { 509588651, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2259), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2257), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2258), 834534160 },
                    { 517164727, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1839), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1836), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1837), 264194405 },
                    { 522007574, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2888), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2885), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2886), 264194405 },
                    { 528237580, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2274), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2271), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2273), 657063491 },
                    { 532196716, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2990), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2987), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2988), 834534160 },
                    { 533136314, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2064), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2061), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2063), 264194405 },
                    { 550574008, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2211), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2208), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2210), 834534160 },
                    { 578870416, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1808), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1805), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1806), 834534160 },
                    { 582464991, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2931), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2929), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2930), 264194405 },
                    { 584123569, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2559), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2557), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2558), 657063491 },
                    { 584706630, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3253), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3250), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3252), 834534160 },
                    { 591979027, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2513), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2510), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2511), 657063491 },
                    { 594261554, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2741), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2738), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2740), 657063491 },
                    { 599209268, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2634), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2632), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2633), 834534160 },
                    { 605633336, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1883), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1880), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1881), 264194405 },
                    { 605909021, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3109), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3106), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3107), 264194405 },
                    { 608313961, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3224), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3222), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3223), 657063491 },
                    { 610892276, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2108), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2105), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2107), 264194405 },
                    { 614331024, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2123), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2120), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2122), 834534160 },
                    { 637433106, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3268), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3265), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3266), 657063491 },
                    { 637469910, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2712), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2709), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2711), 264194405 },
                    { 654931239, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3152), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3150), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3151), 264194405 },
                    { 662048967, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1854), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1851), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1852), 834534160 },
                    { 662244733, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2424), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2421), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2422), 264194405 },
                    { 662862392, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2530), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2527), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2528), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Drawings",
                columns: new[] { "Id", "CompletionDate", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 663241534, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3051), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3049), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3050), 657063491 },
                    { 677620455, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2167), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2165), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2166), 834534160 },
                    { 679146884, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3298), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3294), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3296), 834534160 },
                    { 685108337, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1778), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1775), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1776), 657063491 },
                    { 690155728, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2960), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2958), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2959), 657063491 },
                    { 693129786, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1946), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1943), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1945), 834534160 },
                    { 695450397, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2094), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2091), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2092), 657063491 },
                    { 702662235, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1899), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1896), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1898), 834534160 },
                    { 720071025, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3095), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3092), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3093), 657063491 },
                    { 727891081, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1913), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1911), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1912), 657063491 },
                    { 734332619, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2350), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2347), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2349), 834534160 },
                    { 740163096, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3138), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3135), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3136), 657063491 },
                    { 741951895, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2902), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2900), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2901), 834534160 },
                    { 747712163, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2225), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2223), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2224), 657063491 },
                    { 749463614, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2138), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2135), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2136), 657063491 },
                    { 749827857, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2727), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2724), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2726), 834534160 },
                    { 760100214, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3210), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3207), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3209), 834534160 },
                    { 768938438, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3239), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3236), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3237), 264194405 },
                    { 774325581, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2770), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2767), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2769), 834534160 },
                    { 790216596, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3313), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3311), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3312), 657063491 },
                    { 793944305, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1989), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1987), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1988), 834534160 },
                    { 800430559, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2946), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2943), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2944), 834534160 },
                    { 816769314, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2649), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2646), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2648), 657063491 },
                    { 831310279, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2575), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2572), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2573), 264194405 },
                    { 848354721, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1975), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1972), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1973), 264194405 },
                    { 861383022, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2975), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2973), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2974), 264194405 },
                    { 864035135, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2756), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2753), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2754), 264194405 },
                    { 874809491, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2679), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2676), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2677), 834534160 },
                    { 896791374, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2545), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2542), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2543), 834534160 },
                    { 904233760, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2020), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2018), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2019), 264194405 },
                    { 915688254, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2801), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2799), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2800), 264194405 },
                    { 917369037, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2035), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2032), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2034), 834534160 },
                    { 918859602, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2859), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2857), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2858), 834534160 },
                    { 920132106, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2845), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2842), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2844), 264194405 },
                    { 926371964, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3181), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3178), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3180), 657063491 },
                    { 931332767, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1793), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1790), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1791), 264194405 },
                    { 938458115, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3037), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3035), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3036), 834534160 },
                    { 940218524, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2784), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2782), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2783), 657063491 },
                    { 960896484, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2693), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2691), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2692), 657063491 },
                    { 961832443, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3008), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3005), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3006), 657063491 },
                    { 977582482, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2409), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2406), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2408), 657063491 },
                    { 979904213, new DateTime(2024, 4, 14, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2196), 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2194), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(2195), 264194405 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 126063958, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3618), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3619), 498609019 },
                    { 134473820, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5067), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5068), 852909449 },
                    { 134805857, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3478), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3479), 724276678 },
                    { 139053606, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5662), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5663), 722064785 },
                    { 144509740, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5528), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5529), 724276678 },
                    { 145800218, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4662), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4663), 716360954 },
                    { 146690114, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5306), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5308), 775558853 },
                    { 147698393, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5220), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5221), 722064785 },
                    { 148782614, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5471), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5473), 498609019 },
                    { 151236730, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6629), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6630), 724276678 },
                    { 154936229, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4200), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4201), 498609019 },
                    { 155437173, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6314), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6316), 775558853 },
                    { 157564405, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6453), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6455), 716360954 },
                    { 158145370, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3534), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3535), 207022497 },
                    { 160447486, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4172), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4173), 716360954 },
                    { 166441017, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5108), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5109), 775558853 },
                    { 169239853, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4383), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4385), 852909449 },
                    { 171674864, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4088), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4089), 852909449 },
                    { 173141223, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4269), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4270), 716360954 },
                    { 180004949, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6382), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6384), 498609019 },
                    { 180824655, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4539), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4540), 722064785 },
                    { 181115801, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4983), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4985), 498609019 },
                    { 184525603, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6044), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6045), 722064785 },
                    { 185217033, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5053), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5054), 716360954 },
                    { 190831966, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6413), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6414), 775558853 },
                    { 202648671, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5758), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5759), 722064785 },
                    { 203939403, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4327), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4329), 775558853 },
                    { 214816263, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4827), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4829), 722064785 },
                    { 223455921, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5892), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5893), 852909449 },
                    { 225696179, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4675), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4677), 852909449 },
                    { 226732102, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5744), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5746), 775558853 },
                    { 234424144, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5703), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5704), 852909449 },
                    { 242267469, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3965), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3967), 724276678 },
                    { 245134540, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6481), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6482), 498609019 },
                    { 246959514, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4424), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4426), 775558853 },
                    { 253158146, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5375), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5377), 498609019 },
                    { 256396501, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3687), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3689), 716360954 },
                    { 268707202, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6642), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6644), 716360954 },
                    { 274488782, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4955), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4956), 716360954 },
                    { 278137378, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5389), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5390), 207022497 },
                    { 282594345, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6616), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6617), 722064785 },
                    { 282744356, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4411), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4412), 207022497 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 283092996, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6111), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6112), 207022497 },
                    { 289823663, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3993), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3994), 852909449 },
                    { 295176940, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4942), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4943), 724276678 },
                    { 295442006, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6767), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6769), 498609019 },
                    { 297498086, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6696), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6697), 775558853 },
                    { 299698831, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5011), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5012), 775558853 },
                    { 302397690, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5136), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5137), 724276678 },
                    { 305459711, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3492), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3493), 716360954 },
                    { 309858500, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4928), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4929), 722064785 },
                    { 331535684, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4497), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4498), 498609019 },
                    { 334066236, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5631), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5633), 207022497 },
                    { 342351434, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4397), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4398), 498609019 },
                    { 345017295, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5717), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5718), 498609019 },
                    { 351982007, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4074), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4076), 716360954 },
                    { 354691895, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3771), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3772), 724276678 },
                    { 358210545, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3896), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3897), 852909449 },
                    { 358761038, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3910), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3911), 498609019 },
                    { 359153437, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4021), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4022), 207022497 },
                    { 359446938, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4552), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4553), 724276678 },
                    { 360587055, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5811), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5813), 498609019 },
                    { 368150147, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4914), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4915), 775558853 },
                    { 369934560, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4438), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4440), 722064785 },
                    { 371241452, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4034), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4035), 775558853 },
                    { 373407703, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5265), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5267), 852909449 },
                    { 381845923, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6440), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6441), 724276678 },
                    { 383553101, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6535), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6536), 724276678 },
                    { 384112042, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4773), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4774), 852909449 },
                    { 388643955, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3590), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3592), 716360954 },
                    { 392070281, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6396), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6397), 207022497 },
                    { 395811635, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5852), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5853), 722064785 },
                    { 396118172, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4997), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4998), 207022497 },
                    { 396217945, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4689), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4691), 498609019 },
                    { 404634333, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5555), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5556), 852909449 },
                    { 407733156, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4255), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4256), 724276678 },
                    { 409105923, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3604), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3605), 852909449 },
                    { 411806401, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6287), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6288), 498609019 },
                    { 411963670, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3925), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3926), 207022497 },
                    { 412610174, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4341), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4342), 722064785 },
                    { 413925770, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6780), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6782), 207022497 },
                    { 417726192, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6138), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6140), 722064785 },
                    { 424616608, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5080), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5081), 498609019 },
                    { 427188878, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6369), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6370), 852909449 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 427984797, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6589), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6590), 207022497 },
                    { 431625352, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4128), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4129), 775558853 },
                    { 431741932, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4355), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4356), 724276678 },
                    { 439919129, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4841), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4842), 724276678 },
                    { 442150090, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5838), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5839), 775558853 },
                    { 447600728, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3842), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3843), 775558853 },
                    { 450572624, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4115), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4116), 207022497 },
                    { 450865314, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5293), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5294), 207022497 },
                    { 455495418, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5122), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5123), 722064785 },
                    { 455789061, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3716), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3717), 498609019 },
                    { 456797368, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3979), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3981), 716360954 },
                    { 461832385, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3673), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3674), 724276678 },
                    { 462333272, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5334), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5335), 724276678 },
                    { 470497093, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4882), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4883), 498609019 },
                    { 470954226, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6098), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6099), 498609019 },
                    { 472418252, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3757), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3758), 722064785 },
                    { 475227446, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5417), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5418), 722064785 },
                    { 475583646, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5192), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5193), 207022497 },
                    { 481334510, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5362), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5363), 852909449 },
                    { 488092338, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3576), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3577), 724276678 },
                    { 491893251, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6710), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6712), 722064785 },
                    { 492170232, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3632), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3633), 207022497 },
                    { 498955767, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5279), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5280), 498609019 },
                    { 499524573, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6467), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6469), 852909449 },
                    { 503761209, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4145), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4146), 722064785 },
                    { 506022457, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5932), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5933), 775558853 },
                    { 506852522, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3828), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3829), 207022497 },
                    { 517156757, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5771), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5773), 724276678 },
                    { 519337672, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4635), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4636), 722064785 },
                    { 521958035, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3938), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3939), 775558853 },
                    { 524386225, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4746), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4747), 724276678 },
                    { 525605719, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4855), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4856), 716360954 },
                    { 528568138, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6071), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6072), 716360954 },
                    { 532152993, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6725), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6726), 724276678 },
                    { 532749109, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6656), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6657), 852909449 },
                    { 537219141, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6301), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6302), 207022497 },
                    { 537310341, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5798), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5800), 852909449 },
                    { 537501606, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5444), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5445), 716360954 },
                    { 540688801, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4214), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4215), 207022497 },
                    { 541140804, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4061), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4062), 724276678 },
                    { 548242798, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4703), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4704), 207022497 },
                    { 550123250, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5972), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5974), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 553375523, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3814), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3815), 498609019 },
                    { 557376595, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5959), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5960), 724276678 },
                    { 561666140, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4716), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4718), 775558853 },
                    { 562670575, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5320), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5322), 722064785 },
                    { 568788948, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3454), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3456), 722064785 },
                    { 569890174, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5234), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5235), 724276678 },
                    { 572923330, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5206), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5207), 775558853 },
                    { 573704288, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5825), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5826), 207022497 },
                    { 573913337, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5676), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5677), 724276678 },
                    { 581211026, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6206), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6208), 207022497 },
                    { 582747204, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4299), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4300), 498609019 },
                    { 586901122, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3645), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3647), 775558853 },
                    { 590167047, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4580), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4581), 852909449 },
                    { 591756576, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6179), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6180), 852909449 },
                    { 595457837, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4814), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4815), 775558853 },
                    { 600446950, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5865), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5867), 724276678 },
                    { 609267289, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5918), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5920), 207022497 },
                    { 613470609, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5025), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5026), 722064785 },
                    { 613597598, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4511), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4512), 207022497 },
                    { 618064032, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3883), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3884), 716360954 },
                    { 623142008, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5403), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5404), 775558853 },
                    { 626240035, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4525), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4526), 775558853 },
                    { 629419542, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6273), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6275), 852909449 },
                    { 633021231, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6260), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6262), 716360954 },
                    { 634820096, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6797), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6798), 775558853 },
                    { 646288114, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5500), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5501), 775558853 },
                    { 647524075, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4101), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4103), 498609019 },
                    { 659436530, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3801), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3802), 852909449 },
                    { 661982021, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3730), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3731), 207022497 },
                    { 668791091, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4607), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4609), 207022497 },
                    { 671766057, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5986), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5987), 852909449 },
                    { 677259498, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6669), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6670), 498609019 },
                    { 682314890, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3744), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3745), 775558853 },
                    { 689277252, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5094), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5095), 207022497 },
                    { 690083203, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6233), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6235), 722064785 },
                    { 697262262, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6507), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6509), 775558853 },
                    { 703605342, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6739), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6740), 716360954 },
                    { 704402649, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4800), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4801), 207022497 },
                    { 706651076, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3659), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3661), 722064785 },
                    { 712626673, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3548), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3549), 775558853 },
                    { 719538118, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5999), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6000), 498609019 },
                    { 721191519, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5514), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5515), 722064785 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 723619736, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6494), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6495), 207022497 },
                    { 725464947, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4899), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4901), 207022497 },
                    { 726043906, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5178), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5180), 498609019 },
                    { 726716596, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3787), 1014884392, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3788), 716360954 },
                    { 735137275, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5730), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5731), 207022497 },
                    { 745570230, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6355), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6356), 716360954 },
                    { 746808719, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5648), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5649), 775558853 },
                    { 748330282, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4007), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4008), 498609019 },
                    { 748810018, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6548), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6549), 716360954 },
                    { 751814570, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5247), 1514478272, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5248), 716360954 },
                    { 753217552, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4186), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4188), 852909449 },
                    { 764176679, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5569), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5570), 498609019 },
                    { 768165449, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4648), -13046320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4650), 724276678 },
                    { 775691139, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4480), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4481), 852909449 },
                    { 776786555, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4759), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4760), 716360954 },
                    { 776971727, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3855), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3857), 722064785 },
                    { 785606972, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6219), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6221), 775558853 },
                    { 802893246, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6575), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6577), 498609019 },
                    { 805066220, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6016), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6018), 207022497 },
                    { 805082566, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5039), -1374660912, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5040), 724276678 },
                    { 806352171, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6165), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6167), 716360954 },
                    { 816405029, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3562), 1338483552, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3563), 722064785 },
                    { 821638235, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6193), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6194), 498609019 },
                    { 826282664, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5785), 853549824, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5786), 716360954 },
                    { 827490006, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4731), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4732), 722064785 },
                    { 844215306, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4283), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4285), 852909449 },
                    { 846366107, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3505), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3507), 852909449 },
                    { 848640872, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5485), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5487), 207022497 },
                    { 848772692, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5690), 2058347776, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5691), 716360954 },
                    { 852772967, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6602), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6603), 775558853 },
                    { 853186500, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3869), -2018807360, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3870), 724276678 },
                    { 853941054, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3702), -766589960, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3704), 852909449 },
                    { 854672914, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6562), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6563), 852909449 },
                    { 857022856, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6030), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6031), 775558853 },
                    { 857633717, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5348), 1476244320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5349), 716360954 },
                    { 864372855, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4969), -1025676768, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4970), 852909449 },
                    { 866272710, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5878), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5880), 716360954 },
                    { 868726405, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4869), -1072777880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4870), 852909449 },
                    { 871030929, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5946), 1922016840, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5947), 722064785 },
                    { 871978983, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4466), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4468), 716360954 },
                    { 878843610, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3520), -1765060216, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3521), 498609019 },
                    { 880338149, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5541), 1961561656, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5543), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "Others",
                columns: new[] { "Id", "CompletionEstimation", "CreatedDate", "DisciplineId", "LastUpdatedDate", "TypeId" },
                values: new object[,]
                {
                    { 883144123, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4048), 1249013408, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4049), 722064785 },
                    { 887930821, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4241), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4243), 722064785 },
                    { 890225599, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6085), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6086), 852909449 },
                    { 894269875, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4621), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4622), 775558853 },
                    { 895388749, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4369), 1786998136, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4371), 716360954 },
                    { 896664005, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6328), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6329), 722064785 },
                    { 898531413, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6682), -669688480, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6684), 207022497 },
                    { 902137372, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4228), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4229), 775558853 },
                    { 907582130, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6057), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6058), 724276678 },
                    { 911804476, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6521), 55276880, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6522), 722064785 },
                    { 914745421, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4452), -2043627592, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4454), 724276678 },
                    { 924068678, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4594), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4595), 498609019 },
                    { 924815749, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6426), 761217232, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6428), 722064785 },
                    { 931457317, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5458), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5459), 852909449 },
                    { 933137808, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5151), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5152), 716360954 },
                    { 940829396, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6152), -1466298128, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6153), 724276678 },
                    { 942637849, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6752), 2091716744, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6753), 852909449 },
                    { 943084058, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4158), -2126765688, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4160), 724276678 },
                    { 954651892, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3952), 1735143456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(3953), 722064785 },
                    { 959629463, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5431), 48500184, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5432), 724276678 },
                    { 961225835, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6247), -821294672, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6248), 724276678 },
                    { 962608977, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4787), -1304128112, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4788), 498609019 },
                    { 968602713, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4313), -1461728600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4315), 207022497 },
                    { 970773276, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5165), 858113144, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5166), 852909449 },
                    { 972507514, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6341), -1387564456, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6343), 724276678 },
                    { 972720869, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6125), -2039382160, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(6126), 775558853 },
                    { 991428229, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5905), 903388600, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(5906), 498609019 },
                    { 997987218, 0f, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4566), -1004363320, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(4567), 716360954 }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 130091889, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8133), -399823987, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8135) },
                    { 142482156, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8010), -79753189, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8011) },
                    { 210009642, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8254), -523512980, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8256) },
                    { 357392399, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8177), -965443558, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8180) },
                    { 377058179, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8025), 1456267131, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8026) },
                    { 399056263, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8087), -1117250045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8088) },
                    { 482303752, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8230), 2114720541, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8232) },
                    { 502867731, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7979), -157087754, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7981) },
                    { 535075931, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8151), -54464305, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8153) },
                    { 604322297, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8056), 376250311, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8058) },
                    { 674379550, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7994), 1256897183, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7996) },
                    { 698742277, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8203), 1503073256, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8206) },
                    { 705377858, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8102), 196399036, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8103) },
                    { 710856637, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8072), 1721831396, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8073) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 837327415, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7964), -380484859, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7966) },
                    { 854265727, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8040), -2090907967, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8041) },
                    { 877357391, 524835668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8117), 1507872911, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8119) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[,]
                {
                    { 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7441), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7442), "Project Manager", 524835668 },
                    { 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7426), false, false, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7427), "Secretariat", 524835668 }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[] { 524835668, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9767), 971790611, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9769) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 210009642, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7811), -240334883, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7812) },
                    { 271958213, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7714), -314010958, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7715) },
                    { 377058179, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7729), -441782338, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7731) },
                    { 502867731, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7699), -815869052, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7700) },
                    { 535075931, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7776), -1511620586, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7777) },
                    { 604322297, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7760), -1320640127, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7761) },
                    { 837327415, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7683), 1374444405, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7684) },
                    { 854265727, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7745), 278331976, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7746) },
                    { 876989901, 391103299, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7795), -1803645989, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7796) },
                    { 377058179, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8766), 59970745, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8767) },
                    { 502867731, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8751), 1806634233, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8752) },
                    { 604322297, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8800), 2042824532, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8802) },
                    { 710856637, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8816), -1251164290, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8818) },
                    { 837327415, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8736), -368418838, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8737) },
                    { 854265727, 395911868, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8781), -522286771, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8783) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7456), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7457), "Engineer", 391103299 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 391103299, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(342), 329527785, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(344) },
                    { 391103299, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(357), 282930588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(358) },
                    { 395911868, 825284728, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8932), 925499488, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(8934) },
                    { 391103299, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(326), 291627152, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(328) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 377058179, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7636), -811907041, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7638) },
                    { 479578946, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7621), 142671772, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7623) },
                    { 502867731, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7605), -108336946, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7607) },
                    { 604322297, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7667), -660253486, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7668) },
                    { 837327415, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7589), 344095853, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7590) },
                    { 854265727, 164644045, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7652), 1347976580, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7653) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "IsEditable", "IsEmployee", "LastUpdatedDate", "Name", "ParentRoleId" },
                values: new object[] { 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7470), false, true, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7472), "Designer", 164644045 });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 164644045, 159794805, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9559), 243029691, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9561) },
                    { 164644045, 221583835, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(44), 288570026, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(46) },
                    { 164644045, 222029997, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(225), 905284720, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(226) },
                    { 164644045, 310844693, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9638), 524048362, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9641) },
                    { 164644045, 423324696, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9406), 709301732, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9408) },
                    { 164644045, 481435429, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(179), 408862968, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(181) },
                    { 164644045, 523335748, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9479), 738459459, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9481) },
                    { 164644045, 604231330, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9813), 460668531, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9815) },
                    { 164644045, 667465284, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9738), 720458760, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9739) },
                    { 164644045, 689402813, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(134), 788317312, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(135) },
                    { 164644045, 693577134, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9904), 863035425, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9906) },
                    { 164644045, 804725668, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9953), 939495899, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9955) },
                    { 164644045, 980722489, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(89), 388329060, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(90) },
                    { 164644045, 989427526, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local), 237500796, new DateTime(2024, 4, 3, 14, 44, 8, 325, DateTimeKind.Local).AddTicks(1) },
                    { 164644045, 995610588, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9247), 738501245, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9249) },
                    { 164644045, 997222832, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9859), 511670765, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9860) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 377058179, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7574), -1474443274, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7575) },
                    { 502867731, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7557), -1110510454, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7559) },
                    { 837327415, 479451032, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7529), 1990282307, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(7531) }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "Id", "LastUpdatedDate" },
                values: new object[,]
                {
                    { 479451032, 530043390, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9176), 933319169, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9178) },
                    { 479451032, 590012631, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9105), 726612307, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9107) },
                    { 479451032, 835483227, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9034), 856899277, new DateTime(2024, 4, 3, 14, 44, 8, 324, DateTimeKind.Local).AddTicks(9037) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Roles_RoleId",
                table: "Issues",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
