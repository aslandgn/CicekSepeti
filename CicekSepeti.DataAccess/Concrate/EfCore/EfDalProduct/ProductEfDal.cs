﻿using CicekSepeti.Core.Concrate.ORM;
using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;

namespace CicekSepeti.DataAccess.Concrate.EfCore.EfDalProduct
{
    public class ProductEfDal: EfReposityoryBase<Products>, IProductDal
    {
        public ProductEfDal(CicekSepetiDbContext cicekSepetiDbContext)
        {
            dbContext = cicekSepetiDbContext;
        }
    }
}
