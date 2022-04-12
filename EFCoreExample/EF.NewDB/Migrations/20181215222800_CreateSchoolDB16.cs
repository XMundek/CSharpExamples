using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDT",
                schema: "School",
                table: "Students");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                schema: "School",
                table: "Students",
                nullable: true,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDT",
                schema: "School",
                table: "Students",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDT",
                schema: "School",
                table: "Students",
                nullable: true,
                defaultValueSql: "GetDate()");
        }
    }
}
