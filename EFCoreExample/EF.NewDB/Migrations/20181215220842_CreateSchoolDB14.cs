using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                schema: "School",
                table: "Students",
                newName: "StdName");

            migrationBuilder.AlterColumn<string>(
                name: "StdName",
                schema: "School",
                table: "Students",
                fixedLength: true,
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 300,
                oldDefaultValue: "xxxx");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDT",
                schema: "School",
                table: "Students",
                nullable: false,
                defaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDT",
                schema: "School",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StdName",
                schema: "School",
                table: "Students",
                newName: "StudentName");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                unicode: false,
                fixedLength: true,
                maxLength: 300,
                nullable: false,
                defaultValue: "xxxx",
                oldClrType: typeof(string),
                oldFixedLength: true,
                oldMaxLength: 300);
        }
    }
}
