using CicekSepeti.Entity.Entities.SchemaUser;
using Microsoft.EntityFrameworkCore;

namespace CicekSepeti.DataAccess.Concrate.EntityBuilder.BuilderUser
{
    public class UserBuilder
    {
        internal static void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(x => x.ShoppingCarts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.User_Id)
                .IsRequired()
                ;
        }
    }
}
