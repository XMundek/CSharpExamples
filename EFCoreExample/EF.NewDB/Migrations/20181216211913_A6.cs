using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class A6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StdName",
                schema: "School",
                table: "Students",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "School",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "School",
                table: "Students",
                nullable: true,
                computedColumnSql: "LastName + ' ' + FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "School",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "School",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "School",
                table: "Students",
                newName: "StdName");
        }
    }
}
