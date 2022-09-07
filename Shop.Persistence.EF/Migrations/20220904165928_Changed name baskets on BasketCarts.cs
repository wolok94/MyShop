using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.EF.Migrations
{
    public partial class ChangednamebasketsonBasketCarts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "BasketCarts");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_UserId",
                table: "BasketCarts",
                newName: "IX_BasketCarts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketCarts",
                table: "BasketCarts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketCarts_Users_UserId",
                table: "BasketCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BasketCarts_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "BasketCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BasketCarts_BasketId",
                table: "Products",
                column: "BasketId",
                principalTable: "BasketCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketCarts_Users_UserId",
                table: "BasketCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BasketCarts_BasketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BasketCarts_BasketId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketCarts",
                table: "BasketCarts");

            migrationBuilder.RenameTable(
                name: "BasketCarts",
                newName: "Baskets");

            migrationBuilder.RenameIndex(
                name: "IX_BasketCarts_UserId",
                table: "Baskets",
                newName: "IX_Baskets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Users_UserId",
                table: "Baskets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Baskets_BasketId",
                table: "Products",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
