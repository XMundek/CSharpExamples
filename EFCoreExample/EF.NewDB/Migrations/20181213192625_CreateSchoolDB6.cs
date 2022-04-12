using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DDId",
                table: "XX",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T1",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_XX_DDId",
                table: "XX",
                column: "DDId");

            migrationBuilder.AddForeignKey(
                name: "FK_XX_T1_DDId",
                table: "XX",
                column: "DDId",
                principalTable: "T1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XX_T1_DDId",
                table: "XX");

            migrationBuilder.DropTable(
                name: "T1");

            migrationBuilder.DropIndex(
                name: "IX_XX_DDId",
                table: "XX");

            migrationBuilder.DropColumn(
                name: "DDId",
                table: "XX");
        }
    }
}
