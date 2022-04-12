using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_BookCategories_CategoryId",
                table: "BookCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.EnsureSchema(
                name: "School");

            migrationBuilder.EnsureSchema(
                name: "dictionary");

            migrationBuilder.RenameTable(
                name: "XX",
                newName: "XX",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "T1",
                newName: "T1",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "StudentInfo",
                newName: "StudentInfo",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grades",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "BookCategories",
                newName: "BookCategories",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "AuthorBiography",
                newName: "AuthorBiography",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Author",
                newSchema: "School");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "Category",
                newSchema: "dictionary");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "School",
                table: "Students",
                newName: "StudentName");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryId",
                schema: "dictionary",
                table: "Category",
                newName: "IX_Category_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                schema: "School",
                table: "Students",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                schema: "dictionary",
                table: "Category",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Books_BookId",
                schema: "dictionary",
                table: "Category",
                column: "BookId",
                principalSchema: "School",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_BookCategories_CategoryId",
                schema: "dictionary",
                table: "Category",
                column: "CategoryId",
                principalSchema: "School",
                principalTable: "BookCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Books_BookId",
                schema: "dictionary",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_BookCategories_CategoryId",
                schema: "dictionary",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                schema: "dictionary",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "XX",
                schema: "School",
                newName: "XX");

            migrationBuilder.RenameTable(
                name: "T1",
                schema: "School",
                newName: "T1");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "School",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "StudentInfo",
                schema: "School",
                newName: "StudentInfo");

            migrationBuilder.RenameTable(
                name: "Grades",
                schema: "School",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "School",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "School",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "BookCategories",
                schema: "School",
                newName: "BookCategories");

            migrationBuilder.RenameTable(
                name: "AuthorBiography",
                schema: "School",
                newName: "AuthorBiography");

            migrationBuilder.RenameTable(
                name: "Author",
                schema: "School",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "dictionary",
                newName: "BookCategory");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryId",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Books_BookId",
                table: "BookCategory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_BookCategories_CategoryId",
                table: "BookCategory",
                column: "CategoryId",
                principalTable: "BookCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
