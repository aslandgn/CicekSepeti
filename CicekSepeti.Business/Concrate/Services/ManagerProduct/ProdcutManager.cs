using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;

namespace CicekSepeti.Business.Concrate.Services.ManagerProduct
{
    public class ProdcutManager : ManagerBase<Products, long, IProductDal>, IProductService
    {
        public ProdcutManager(IProductDal productDal)
        {
            _manager = productDal;
        }
    }
}
