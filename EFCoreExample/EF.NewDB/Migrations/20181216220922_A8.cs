using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class A8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "TestSeq",
                schema: "School",
                startValue: 100L,
                incrementBy: 2);

            migrationBuilder.CreateTable(
                name: "PersonSeq",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR School.TestSeq"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSeq", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonSeq",
                schema: "School");

            migrationBuilder.DropSequence(
                name: "TestSeq",
                schema: "School");
        }
    }
}
