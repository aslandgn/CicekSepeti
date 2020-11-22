using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.Business.Abstract.Services.ServiceShopping;
using CicekSepeti.Business.Abstract.Services.ServiceUser;
using CicekSepeti.Business.Concrate.Services.ManagerProduct;
using CicekSepeti.Business.Concrate.Services.ManagerShopping;
using CicekSepeti.Business.Concrate.Services.ManagerUser;
using CicekSepeti.DataAccess.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepeti.Business.Injections
{
    /// <summary>
    /// business katmanındaki servislerin dependency injectionlarını oluşturuğum sınıf
    /// </summary>
    public static class BusinessServiceInjections
    {
        public static void Initialize(IServiceCollection services)
        {
            DataAccessInjections.Initialize(services);
            #region Product
            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<IProductService, ProdcutManager>();
            #endregion
            #region User
            services.AddTransient<IUserService, UserManager>();
            #endregion
            #region Shopping
            services.AddTransient<IShoppingCartService, ShoppingCartManager>();
            services.AddTransient<IShoppingCartItemService, ShoppingCartItemManager>();
            #endregion
        }

    }
}
