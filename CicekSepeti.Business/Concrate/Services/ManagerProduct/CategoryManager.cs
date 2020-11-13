using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;

namespace CicekSepeti.Business.Concrate.Services.ManagerProduct
{
    public class CategoryManager : ManagerBase<Categories, long, ICategoryDal>, ICategoryService
    {
        public CategoryManager(ICategoryDal productDal)
        {
            _manager = productDal;
        }
    }
}
