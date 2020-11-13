using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CicekSepeti.Entity.Migrations.MigrationUrunProduct
{
    public static class CategoryMigrationHelper
    {
        internal static void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               schema: "PRODUCT",
               name: "Categories",
               columns: table => new
               {
                   ID = table.Column<long>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   NAME = table.Column<string>(nullable: true),
                   ORDER = table.Column<string>(nullable: false),
                   ROOT_CATEGORY_ID = table.Column<long>(nullable: true),
                   STATUS = table.Column<bool>(nullable: false),
                   IS_DELETED = table.Column<bool>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Category", x => x.ID);
                   table.ForeignKey(
                       name: "FK_Category_Category",
                       column: x => x.ROOT_CATEGORY_ID,
                       principalSchema: "PRODUCT",
                       principalTable: "Categories",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade
                       );
               });

        }
    }
}
