using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "School",
                table: "Person");

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                schema: "School",
                table: "Person",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "School",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "School",
                table: "Person",
                nullable: false,
                defaultValue: "");
        }
    }
}
