using CicekSepeti.Business.Abstract.Services.ServiceShopping;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;

namespace CicekSepeti.Business.Concrate.Services.ManagerShopping
{
    public class ShoppingCartManager : ManagerBase<ShoppingCarts, long, IShoppingCartDal>, IShoppingCartService
    {
    }
}
