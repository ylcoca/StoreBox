using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreBox.Entities.Migrations
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_type_name",
                table: "ProductType",
                newName: "product_type_name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_type_name",
                table: "ProductType",
                newName: "Product_type_name");
        }
    }
}
