using CicekSepeti.Core.Concrate.ORM;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;

namespace CicekSepeti.DataAccess.Concrate.EfCore.EfDalShopping
{
    public class ShoppingCartEfDal: EfReposityoryBase<ShoppingCarts>, IShoppingCartDal
    {
    }
}
