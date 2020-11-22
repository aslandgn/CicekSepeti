using CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderProduct;
using CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderShopping;
using CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderUser;
using CicekSepeti.Entity.Entities.SchemaProduct;
using CicekSepeti.Entity.Entities.SchemaShopping;
using CicekSepeti.Entity.Entities.SchemaUser;
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
        #region User
        public DbSet<Users> Users { get; set; }
        #endregion
        #region Shopping
        public DbSet<ShoppingCarts> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        #endregion
        //public DbSet<Test> Tests{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product
            CategoryBuilder.Build(modelBuilder);
            ProductBuilder.Build(modelBuilder);
            #endregion
            #region User
            UserBuilder.Build(modelBuilder);
            #endregion
            #region Shopping
            ShoppingCartBuilder.Build(modelBuilder);
            ShoppingCartItemBuilder.Build(modelBuilder);
            #endregion
        }
    }
}
