using Microsoft.EntityFrameworkCore.Migrations;

namespace CicekSepeti.DataAccess.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PRODUCT");

            migrationBuilder.EnsureSchema(
                name: "SHOPPING");

            migrationBuilder.EnsureSchema(
                name: "USER");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "PRODUCT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Root_Category_Id = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_Root_Category_Id",
                        column: x => x.Root_Category_Id,
                        principalSchema: "PRODUCT",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "PRODUCT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Product_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalSchema: "PRODUCT",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "SHOPPING",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_User_Id",
                        column: x => x.User_Id,
                        principalSchema: "USER",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "SHOPPING",
                columns: table => new
                {
                    ShoppingCart_Id = table.Column<long>(type: "bigint", nullable: false),
                    Product_Id = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => new { x.Product_Id, x.ShoppingCart_Id });
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalSchema: "PRODUCT",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCart_Id",
                        column: x => x.ShoppingCart_Id,
                        principalSchema: "SHOPPING",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Root_Category_Id",
                schema: "PRODUCT",
                table: "Categories",
                column: "Root_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_Id",
                schema: "PRODUCT",
                table: "Products",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCart_Id",
                schema: "SHOPPING",
                table: "ShoppingCartItem",
                column: "ShoppingCart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_User_Id",
                schema: "SHOPPING",
                table: "ShoppingCarts",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "SHOPPING");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "PRODUCT");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "SHOPPING");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "PRODUCT");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "USER");
        }
    }
}
