using CicekSepeti.Core.Concrate.ORM;
using CicekSepeti.DataAccess.Abstract.DalUser;
using CicekSepeti.Entity.Entities.SchemaUser;

namespace CicekSepeti.DataAccess.Concrate.EfCore.EfDAlUser
{
    public class UserEfDal : EfReposityoryBase<Users>, IUserDal
    {
        public UserEfDal(CicekSepetiDbContext cicekSepetiDbContext)
        {
            dbContext = cicekSepetiDbContext;
        }
    }
}
