using AutoMapper;
using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;
using System;

namespace CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperProduct
{
    public static class ProductMapper
    {
        public static void getConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<Products, ProductDto>()
            .ForMember(dest => dest.id, conf => conf.MapFrom(src => src.Id))
            .ForMember(dest => dest.productName, conf => conf.MapFrom(src => src.Name))
            .ForMember(dest => dest.status, conf => conf.MapFrom(src => Convert.ToInt32(src.Status)))
                ;
            config.CreateMap<Products, Products>()
                ;
        }
    }
}
