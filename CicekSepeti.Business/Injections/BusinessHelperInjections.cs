using CicekSepeti.Business.Abstract.Helpers.HelperProduct;
using CicekSepeti.Business.Abstract.Helpers.HelperShopping;
using CicekSepeti.Business.Abstract.Helpers.HelperUser;
using CicekSepeti.Business.Concrate.Helpers.HelperProduct;
using CicekSepeti.Business.Concrate.Helpers.HelperShopping;
using CicekSepeti.Business.Concrate.Helpers.HelperUser;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepeti.Business.Injections
{
    /// <summary>
    /// business katmanındaki servislerin dependency injectionlarını oluşturuğum sınıf
    /// </summary>
    public static class BusinessHelperInjections
    {
        public static void Initialize(IServiceCollection services)
        {
            #region Product
            services.AddTransient<ICategoryHelper, CategoryHelper>();
            services.AddTransient<IProductHelper, ProductHelper>();
            #endregion
            #region User
            services.AddTransient<IUserHelper, UserHelper>();
            #endregion
            #region Shopping
            services.AddTransient<IShoppingCartHelper, ShoppingCartHelper>();
            services.AddTransient<IShoppingCartItemHelper, ShoppingCartItemHelper>();
            #endregion
        }

    }
}
