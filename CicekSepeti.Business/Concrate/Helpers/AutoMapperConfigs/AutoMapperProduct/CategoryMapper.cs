using AutoMapper;
using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;

namespace CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperProduct
{
    public static class CategoryMapper
    {
        public static void getConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<Categories, CategoryDto>()
            .ForMember(dest => dest.id, conf => conf.MapFrom(src => src.Id))
            .ForMember(dest => dest.categoryName, conf => conf.MapFrom(src => src.Name))
            .ForMember(dest => dest.rootCategoryId, conf => conf.MapFrom(src => src.Root_Category_Id))
            .ForMember(dest => dest.rootCategoryName, conf => conf.MapFrom(src => src.RootCategory.Name))
            .ForMember(dest => dest.status, conf => conf.MapFrom(src => src.Status))
                ;
            config.CreateMap<Categories, Categories>()
                ;
            config.CreateMap<CategoryDto, Categories>()
            .ForMember(dest => dest.Id, conf => conf.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, conf => conf.MapFrom(src => src.categoryName))
            .ForMember(dest => dest.Status, conf => conf.MapFrom(src => src.status))
            .ForMember(dest => dest.Root_Category_Id, conf => conf.MapFrom(src => src.rootCategoryId))
            ;
        }
    }
}
