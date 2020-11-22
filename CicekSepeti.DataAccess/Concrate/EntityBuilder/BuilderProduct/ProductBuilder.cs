using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderProduct
{
    public static class ProductBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasMany(x => x.ShoppingCartItems)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.Product_Id)
                .IsRequired()
                ;
            modelBuilder.Entity<Products>()
                .Property(x => x.Price)
                .HasPrecision(18, 6);
        }
    }
}
