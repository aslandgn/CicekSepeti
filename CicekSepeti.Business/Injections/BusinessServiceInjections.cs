using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.Business.Concrate.Services.ManagerProduct;
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

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<IProductService, ProdcutManager>();
        }

    }
}
