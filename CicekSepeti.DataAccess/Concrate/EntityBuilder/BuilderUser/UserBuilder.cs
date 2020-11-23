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
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Name = "test1",
                    SurName = "test1",
                    Password = "test1",
                    Status = true,
                    Is_Deleted = false,
                });
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 2,
                    Name = "test2",
                    SurName = "test2",
                    Password = "test2",
                    Status = true,
                    Is_Deleted = false,
                });
        }
    }
}
