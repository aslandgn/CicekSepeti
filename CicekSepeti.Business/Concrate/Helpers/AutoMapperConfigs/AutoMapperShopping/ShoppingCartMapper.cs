using AutoMapper;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using System.Linq;

namespace CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperShopping
{
    public static class ShoppingCartMapper
    {
        internal static void getConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<ShoppingCarts, ShoppingCarts>();
            
            config.CreateMap<ShoppingCarts, ShoppingCartDto>()
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.User_Id))
                .ForMember(dest => dest.total, opt => opt.MapFrom(src => src.ShoppingCartItems.Sum(x => x.Product.Price * x.Quantity)))
                .ForMember(dest => dest.products, opt => opt.MapFrom(src => src.ShoppingCartItems))
                ;

        }
    }
}
