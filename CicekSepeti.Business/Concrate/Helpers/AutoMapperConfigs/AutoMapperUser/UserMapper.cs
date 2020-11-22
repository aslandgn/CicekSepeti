using AutoMapper;
using CicekSepeti.Dto.WebUiDtos.DtoUser;
using CicekSepeti.Entity.Entities.SchemaUser;

namespace CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperUser
{
    public static class UserMapper
    {
        public static void getConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<Users, UserModel>()
            .ForMember(dest => dest.id, conf => conf.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, conf => conf.MapFrom(src => src.Name))
            .ForMember(dest => dest.password, conf => conf.MapFrom(src => string.Empty))
                ;
            config.CreateMap<Users, Users>()
                ;
        }
    }
}
