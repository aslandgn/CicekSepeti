using CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DataAccess.Concrate
{
    public class CicekSepetiDbContext : DbContext
    {
        public CicekSepetiDbContext(DbContextOptions options)
           : base(options)
        { }
        #region Product
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product
            CategoryBuilder.Build(modelBuilder);
            ProductBuilder.Build(modelBuilder);
            #endregion
        }
    }
}
