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
                    Total = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
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

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Categories",
                columns: new[] { "Id", "Is_Deleted", "Name", "Order", "Root_Category_Id", "Status" },
                values: new object[,]
                {
                    { 1L, false, "category1", 1, null, true },
                    { 2L, false, "category2", 2, null, true }
                });

            migrationBuilder.InsertData(
                schema: "USER",
                table: "Users",
                columns: new[] { "Id", "Is_Deleted", "Name", "Password", "Status", "SurName" },
                values: new object[,]
                {
                    { 1, false, "test1", "test1", true, "test1" },
                    { 2, false, "test2", "test2", true, "test2" }
                });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Categories",
                columns: new[] { "Id", "Is_Deleted", "Name", "Order", "Root_Category_Id", "Status" },
                values: new object[] { 3L, false, "childcategory3ofc1", 3, 1L, true });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Products",
                columns: new[] { "Id", "Category_Id", "InStock", "Is_Deleted", "Name", "Order", "Price", "Product_Code", "Status" },
                values: new object[] { 1L, 1L, 5, false, "product1", 1, 1000m, "pCode1", true });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Categories",
                columns: new[] { "Id", "Is_Deleted", "Name", "Order", "Root_Category_Id", "Status" },
                values: new object[] { 4L, false, "childcategory4ofc3", 4, 3L, true });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Products",
                columns: new[] { "Id", "Category_Id", "InStock", "Is_Deleted", "Name", "Order", "Price", "Product_Code", "Status" },
                values: new object[] { 2L, 3L, 1500, false, "product2", 2, 200m, "pCode2", true });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Products",
                columns: new[] { "Id", "Category_Id", "InStock", "Is_Deleted", "Name", "Order", "Price", "Product_Code", "Status" },
                values: new object[] { 3L, 4L, 0, false, "product3", 3, 300m, "pCode3", true });

            migrationBuilder.InsertData(
                schema: "PRODUCT",
                table: "Products",
                columns: new[] { "Id", "Category_Id", "InStock", "Is_Deleted", "Name", "Order", "Price", "Product_Code", "Status" },
                values: new object[] { 4L, 4L, 100000, false, "product4", 4, 20m, "pCode4", true });

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
