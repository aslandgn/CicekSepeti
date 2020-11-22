using CicekSepeti.Core.Concrate.ORM;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;

namespace CicekSepeti.DataAccess.Concrate.EfCore.EfDalShopping
{
    public class ShoppingCartItemEfDal : EfReposityoryBase<ShoppingCartItems>, IShoppingCartItemDal
    {
        public ShoppingCartItemEfDal(CicekSepetiDbContext cicekSepetiDbContext)
        {
            dbContext = cicekSepetiDbContext;
        }
    }
}
