using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreBox.Entities.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    product_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_type_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    width = table.Column<float>(type: "real", nullable: false),
                    symbol = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.product_type_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                columns: table => new
                {
                    product_order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => x.product_order_id);
                    table.ForeignKey(
                        name: "FK_Order_OrderId",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_ProductType_ProductTypeID",
                        column: x => x.product_type_id,
                        principalTable: "ProductType",
                        principalColumn: "product_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_order_id",
                table: "ProductOrder",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_product_type_id",
                table: "ProductOrder",
                column: "product_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
