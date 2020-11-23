using AutoMapper;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Business.Concrate.Helpers.AutoMapperConfigs.AutoMapperShopping
{
    public static class ShoppingCartItemMapper
    {
        internal static void getConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<ShoppingCartItems, ShoppingCartItems>();

            config.CreateMap<ShoppingCartItems, ShoppingCartAddItemDto>();
            
            config.CreateMap<ShoppingCartItems, ShoppingCartItemDto>()
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.Product_Id))
                .ForMember(dest => dest.cartId, opt => opt.MapFrom(src => src.ShoppingCart_Id))
                ;
        }
    }
}
