using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.NewDB.Migrations
{
    public partial class CreateSchoolDB28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_PersonT_Id",
                schema: "School",
                table: "EmployeeT");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                schema: "School",
                table: "EmployeeT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeT_PersonId",
                schema: "School",
                table: "EmployeeT",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_PersonT_PersonId",
                schema: "School",
                table: "EmployeeT",
                column: "PersonId",
                principalSchema: "School",
                principalTable: "PersonT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeT_PersonT_PersonId",
                schema: "School",
                table: "EmployeeT");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeT_PersonId",
                schema: "School",
                table: "EmployeeT");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "School",
                table: "EmployeeT");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeT_PersonT_Id",
                schema: "School",
                table: "EmployeeT",
                column: "Id",
                principalSchema: "School",
                principalTable: "PersonT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
