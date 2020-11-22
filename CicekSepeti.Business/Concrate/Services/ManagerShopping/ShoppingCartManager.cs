using CicekSepeti.Business.Abstract.Services.ServiceShopping;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Services.ManagerShopping
{
    public class ShoppingCartManager : ManagerBase<ShoppingCarts, long, IShoppingCartDal>, IShoppingCartService
    {
        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _manager = shoppingCartDal;
        }
        public async Task<List<ShoppingCarts>> GetListWithShoppingCartItems_ShoppingCarts(Expression<Func<ShoppingCarts, bool>> filter = null)
        {
            Func<IQueryable<ShoppingCarts>, IIncludableQueryable<ShoppingCarts, object>> includes = source => source.
                 Include(x => x.ShoppingCartItems)
                 .ThenInclude(x => x.Product)
                 .Include(x => x.User);
            return await _manager.GetList(includes, filter);
        }
    }
}
