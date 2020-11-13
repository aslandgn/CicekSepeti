using CicekSepeti.Business.Abstract.Helpers.HelperProduct;
using CicekSepeti.Business.Concrate.Helpers.HelperProduct;
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
            services.AddSingleton<ICategoryHelper, CategoryHelper>();
            services.AddSingleton<IProductHelper, ProductHelper>();
        }

    }
}
