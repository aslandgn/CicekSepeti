using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore;
using System;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderProduct
{
    public static class CategoryBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(x => x.ChildCategories)
                .WithOne(x => x.RootCategory)
                ;
            modelBuilder.Entity<Categories>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .IsRequired()
                ;
        }
    }
}
