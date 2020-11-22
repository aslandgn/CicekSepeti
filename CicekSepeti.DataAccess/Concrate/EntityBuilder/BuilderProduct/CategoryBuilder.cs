using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderProduct
{
    public static class CategoryBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(x => x.ChildCategories)
                .WithOne(x => x.RootCategory)
                .HasForeignKey(x => x.Root_Category_Id)
                ;

            modelBuilder.Entity<Categories>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.Category_Id)
                .IsRequired()
                ;
        }
    }
}
