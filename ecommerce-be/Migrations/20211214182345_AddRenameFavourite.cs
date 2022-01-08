using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_be.Migrations
{
    public partial class AddRenameFavourite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFavorite",
                table: "Products",
                newName: "isFavourite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFavourite",
                table: "Products",
                newName: "isFavorite");
        }
    }
}
