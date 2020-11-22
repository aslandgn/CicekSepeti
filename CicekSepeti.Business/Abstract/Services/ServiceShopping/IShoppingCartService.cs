using CicekSepeti.Entity.Entities.SchemaShopping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Services.ServiceShopping
{
    public interface IShoppingCartService: IServiceBase<ShoppingCarts>
    {
        Task<List<ShoppingCarts>> GetListWithShoppingCartItems_ShoppingCarts(Expression<Func<ShoppingCarts, bool>> filter = null);
    }
}
