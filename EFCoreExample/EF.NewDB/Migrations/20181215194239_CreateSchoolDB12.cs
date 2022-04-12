using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                maxLength: 300,
                nullable: false,
                defaultValue: "xxxx",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldDefaultValue: "xxxx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "xxxx",
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldDefaultValue: "xxxx");
        }
    }
}
