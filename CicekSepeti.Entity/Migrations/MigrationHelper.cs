using CicekSepeti.Entity.Migrations.MigrationUrunProduct;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CicekSepeti.Entity.Migrations
{
    public class MigrationHelper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Product
            CategoryMigrationHelper.Up(migrationBuilder);
            ProductMigrationHelper.Up(migrationBuilder);
            #endregion
        }
    }
}
