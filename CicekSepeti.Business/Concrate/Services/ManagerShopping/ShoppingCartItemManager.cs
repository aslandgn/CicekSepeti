using CicekSepeti.Business.Abstract.Services.ServiceShopping;
using CicekSepeti.Business.Concrate.Services.ManagerUser;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;

namespace CicekSepeti.Business.Concrate.Services.ManagerShopping
{
    public class ShoppingCartItemManager : ManagerBaseWoPrimary<ShoppingCartItems, IShoppingCartItemDal>, IShoppingCartItemService
    {
        public ShoppingCartItemManager(IShoppingCartItemDal shoppingCartItemDal)
        {
            _manager = shoppingCartItemDal;
        }
    }
}
