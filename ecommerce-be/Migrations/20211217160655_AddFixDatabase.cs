using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce_be.Migrations
{
    public partial class AddFixDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "RoomChats");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Chats");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomChats",
                table: "RoomChats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomChats",
                table: "RoomChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "RoomChats",
                newName: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");
        }
    }
}
