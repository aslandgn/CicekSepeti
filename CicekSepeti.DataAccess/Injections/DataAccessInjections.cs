using CicekSepeti.DataAccess.Abstract.DalProduct;
using CicekSepeti.DataAccess.Concrate.EfCore.EfDalProduct;
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
            services.AddTransient<ICategoryDal, CategoryEfDal>();
            services.AddTransient<IProductDal, ProductEfDal>();
        }

    }
}
