using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.EF.Migrations
{
    public partial class Newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCarts",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_CustomerId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ShoppingCarts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
