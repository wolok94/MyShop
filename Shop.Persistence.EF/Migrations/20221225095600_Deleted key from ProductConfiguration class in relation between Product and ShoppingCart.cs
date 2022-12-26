using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Persistence.EF.Migrations
{
    public partial class DeletedkeyfromProductConfigurationclassinrelationbetweenProductandShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCart",
                table: "ProductCart",
                columns: new[] { "ProductId", "ShoppingCartId" });
        }
    }
}
