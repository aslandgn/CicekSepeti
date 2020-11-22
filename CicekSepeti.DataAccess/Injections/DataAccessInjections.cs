using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.DataAccess.Abstract.DalShopping;
using CicekSepeti.DataAccess.Abstract.DalUser;
using CicekSepeti.DataAccess.Concrate.EfCore.EfDalProduct;
using CicekSepeti.DataAccess.Concrate.EfCore.EfDalShopping;
using CicekSepeti.DataAccess.Concrate.EfCore.EfDAlUser;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepeti.DataAccess.Injections
{
    /// <summary>
    /// dataAccess katmanındaki servislerin dependency injectionlarını oluşturuğum sınıf
    /// </summary>
    public static class DataAccessInjections
    {
        public static void Initialize(IServiceCollection services)
        {
            #region Product
            services.AddTransient<ICategoryDal, CategoryEfDal>();
            services.AddTransient<IProductDal, ProductEfDal>();
            #endregion
            #region User
            services.AddTransient<IUserDal, UserEfDal>();
            #endregion
            #region Shopping
            services.AddTransient<IShoppingCartDal, ShoppingCartEfDal>();
            services.AddTransient<IShoppingCartItemDal, ShoppingCartItemEfDal>();
            #endregion
        }

    }
}
