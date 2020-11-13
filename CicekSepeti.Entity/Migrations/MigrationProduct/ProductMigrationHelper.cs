using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CicekSepeti.Entity.Migrations.MigrationUrunProduct
{
    public static class ProductMigrationHelper
    {
        internal static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               schema: "PRODUCT",
               name: "Products",
               columns: table => new
               {
                   ID = table.Column<long>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   NAME = table.Column<string>(nullable: true),
                   ORDER = table.Column<string>(nullable: false),
                   PRODUCT_CODE = table.Column<string>(nullable: true),
                   PRICE = table.Column<decimal>(nullable: false),
                   CATEGORY_ID = table.Column<long>(nullable: false),
                   STATUS = table.Column<bool>(nullable: false),
                   IS_DELETED = table.Column<bool>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Product", x => x.ID);
                   table.UniqueConstraint("UN_Product", x => x.PRODUCT_CODE);
                   table.ForeignKey(
                       name: "FK_Product_Category",
                       column: x => x.CATEGORY_ID,
                       principalSchema: "PRODUCT",
                       principalTable: "Categories",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade
                       );
               });

        }
    }
}
