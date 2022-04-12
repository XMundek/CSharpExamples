using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Query.Migrations
{
    public partial class a16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Products",
                nullable: true);
        }
    }
}
