using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Helpers.HelperShopping
{
    public interface IShoppingCartHelper
    {
        Task<ShoppingCartDto> ShowCart(int userId);
        Task ClearCart(long cartId);
        Task<ShoppingCartDto> CompleteShopping(long cartId);
    }
}
