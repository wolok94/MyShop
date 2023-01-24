using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.EF.Migrations
{
    public partial class AddedquantityinProductCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductCart",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductCart",
                newName: "Id");
        }
    }
}
