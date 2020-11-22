using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Helpers.HelperShopping
{
    public interface IShoppingCartItemHelper
    {
        Task<ShoppingCartItems> AddItemToCart(ShoppingCartAddItemModel model, int userId);
    }
}
