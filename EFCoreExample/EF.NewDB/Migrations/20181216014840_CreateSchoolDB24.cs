using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "EmployeeTpt_PersonId",
                schema: "School",
                table: "PersonT");
        }
    }
}
