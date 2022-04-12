using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                oldMaxLength: 300,
                oldDefaultValue: "xxxx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                maxLength: 300,
                nullable: false,
                defaultValue: "xxxx",
                oldClrType: typeof(string),
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 300,
                oldDefaultValue: "xxxx");
        }
    }
}
