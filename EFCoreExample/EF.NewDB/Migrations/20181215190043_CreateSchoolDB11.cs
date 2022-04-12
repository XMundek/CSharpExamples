using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "xxxx",
                oldClrType: typeof(string),
                oldType: "varchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldDefaultValue: "xxxx");
        }
    }
}
