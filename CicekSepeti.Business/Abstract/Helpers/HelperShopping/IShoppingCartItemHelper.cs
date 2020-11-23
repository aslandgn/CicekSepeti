using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Helpers.HelperShopping
{
    public interface IShoppingCartItemHelper
    {
        Task<ShoppingCartItems> AddItemToCart(ShoppingCartAddItemDto model, int userId);
        Task<ShoppingCartItemDto> ChangeQuantity(ShoppingCartItemDto dto);
        Task Delete(ShoppingCartItemDto dto);
    }
}
