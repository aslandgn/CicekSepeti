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
            modelBuilder.Entity<Categories>()
                .HasData(new Categories
                {
                    Id = 1,
                    Name = "category1",
                    Order = 1,
                    Root_Category_Id = null,
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Categories>()
                .HasData(new Categories
                {
                    Id = 2,
                    Name = "category2",
                    Order = 2,
                    Root_Category_Id = null,
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Categories>()
                .HasData(new Categories
                {
                    Id = 3,
                    Name = "childcategory3ofc1",
                    Order = 3,
                    Root_Category_Id = 1,
                    Status = true,
                    Is_Deleted = false
                });
            modelBuilder.Entity<Categories>()
                .HasData(new Categories
                {
                    Id = 4,
                    Name = "childcategory4ofc3",
                    Order = 4,
                    Root_Category_Id = 3,
                    Status = true,
                    Is_Deleted = false
                });
        }
    }
}
