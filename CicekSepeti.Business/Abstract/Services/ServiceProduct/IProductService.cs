using CicekSepeti.Entity.Entities.SchemaProduct;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Services.ServiceProduct
{
    public interface IProductService : IServiceBase<Products>
    {
        Task<List<Products>> GetListWithShoppingCartItems_Products(Expression<Func<Products, bool>> filter = null);
    }
}
