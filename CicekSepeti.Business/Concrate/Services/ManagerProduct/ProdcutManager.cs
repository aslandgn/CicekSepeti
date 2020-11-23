using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Services.ManagerProduct
{
    public class ProdcutManager : ManagerBase<Products, long, IProductDal>, IProductService
    {
        public ProdcutManager(IProductDal productDal)
        {
            _manager = productDal;
        }

        public async Task<List<Products>>  GetListWithShoppingCartItems_Products(Expression<Func<Products, bool>> filter = null)
        {
            Func<IQueryable<Products>, IIncludableQueryable<Products, object>> includes = source => source.
                 Include(x => x.ShoppingCartItems);
            return await _manager.GetList(includes, filter);
        }
    }
}
