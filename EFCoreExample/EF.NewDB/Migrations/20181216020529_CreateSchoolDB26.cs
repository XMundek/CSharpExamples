using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonT_PersonT_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonT_PersonT_EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropIndex(
                name: "IX_PersonT_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropIndex(
                name: "IX_PersonT_EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "Salary",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "School",
                table: "PersonT");

            migrationBuilder.CreateTable(
                name: "CustomerT",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerT_PersonT_Id",
                        column: x => x.Id,
                        principalSchema: "School",
                        principalTable: "PersonT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeT",
                schema: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeT_PersonT_Id",
                        column: x => x.Id,
                        principalSchema: "School",
                        principalTable: "PersonT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerT",
                schema: "School");

            migrationBuilder.DropTable(
                name: "EmployeeT",
                schema: "School");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "School",
                table: "PersonT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                schema: "School",
                table: "PersonT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                schema: "School",
                table: "PersonT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "School",
                table: "PersonT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonT_PersonId",
                schema: "School",
                table: "PersonT",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonT_EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT",
                column: "EmployeeTpt_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonT_PersonT_PersonId",
                schema: "School",
                table: "PersonT",
                column: "PersonId",
                principalSchema: "School",
                principalTable: "PersonT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonT_PersonT_EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT",
                column: "EmployeeTpt_PersonId",
                principalSchema: "School",
                principalTable: "PersonT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
