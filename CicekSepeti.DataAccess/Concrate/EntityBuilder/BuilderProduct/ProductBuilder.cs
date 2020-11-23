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

            modelBuilder.Entity<Products>()
                .HasData(new Products
                {
                    Id = 1,
                    Name = "product1",
                    Order = 1,
                    Category_Id = 1,
                    InStock = 5,
                    Price = 1000,
                    Product_Code = "pCode1",
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Products>()
                .HasData(new Products
                {
                    Id = 2,
                    Name = "product2",
                    Order = 2,
                    Category_Id = 3,
                    InStock = 1500,
                    Price = 200,
                    Product_Code = "pCode2",
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Products>()
                .HasData(new Products
                {
                    Id = 3,
                    Name = "product3",
                    Order = 3,
                    Category_Id = 4,
                    InStock = 0,
                    Price = 300,
                    Product_Code = "pCode3",
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Products>()
                .HasData(new Products
                {
                    Id = 4,
                    Name = "product4",
                    Order = 4,
                    Category_Id = 4,
                    InStock = 100000,
                    Price = 20,
                    Product_Code = "pCode4",
                    Status = true,
                    Is_Deleted = false
                });
        }
    }
}
