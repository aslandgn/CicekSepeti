using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderShopping
{
    public class ShoppingCartItemBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartItems>()
                .HasKey(x => new { x.Product_Id, x.ShoppingCart_Id })
                ;

        }
    }
}
