using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.EF.Migrations
{
    public partial class AddedIdinProductCartclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductCart",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCart");
        }
    }
}
