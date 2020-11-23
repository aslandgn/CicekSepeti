using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderShopping
{
    public class ShoppingCartBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCarts>()
                .HasMany(x => x.ShoppingCartItems)
                .WithOne(x => x.ShoppingCart)
                .HasForeignKey(x => x.ShoppingCart_Id)
                .IsRequired()
                ;
            modelBuilder.Entity<ShoppingCarts>()
                .Property(x => x.Total)
                .HasPrecision(18, 6);
        }
    }
}
