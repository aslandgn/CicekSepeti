using CicekSepeti.Business.Abstract.Services.ServiceUser;
using CicekSepeti.DataAccess.Abstract.DalUser;
using CicekSepeti.Entity.Entities.SchemaUser;

namespace CicekSepeti.Business.Concrate.Services.ManagerUser
{
    public class UserManager : ManagerBase<Users, int, IUserDal>, IUserService
    {
        public UserManager(IUserDal userDal) {
            _manager = userDal;
        }
    }
}
