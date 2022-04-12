using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class a12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonT_PersonT_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropIndex(
                name: "IX_PersonT_PersonId",
                schema: "School",
                table: "PersonT");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "School",
                table: "PersonT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                schema: "School",
                table: "PersonT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonT_PersonId",
                schema: "School",
                table: "PersonT",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonT_PersonT_PersonId",
                schema: "School",
                table: "PersonT",
                column: "PersonId",
                principalSchema: "School",
                principalTable: "PersonT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
