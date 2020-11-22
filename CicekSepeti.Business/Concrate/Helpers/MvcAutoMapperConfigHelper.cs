using AutoMapper;
using CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperProduct;
using CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperUser;

namespace CicekSepeti.Business.Concrate.Helpers
{
    public class MvcAutoMapperConfigHelper : Profile
    {
        public MvcAutoMapperConfigHelper(IMapperConfigurationExpression cfg)
        {
            #region Product
            CategoryMapper.getConfig(cfg);
            ProductMapper.getConfig(cfg);
            #endregion
            #region User
            UserMapper.getConfig(cfg);
            #endregion
        }
    }
}
