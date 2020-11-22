using CicekSepeti.Business.Abstract.Helpers.HelperShopping;
using CicekSepeti.Business.Abstract.Services.ServiceShopping;
using CicekSepeti.Business.Abstract.Services.ServiceUser;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Helpers.HelperShopping
{
    public class ShoppingCartItemHelper : IShoppingCartItemHelper
    {
        #region services
        private readonly IShoppingCartHelper _shoppingCartHelper;
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        #endregion
        public ShoppingCartItemHelper(IShoppingCartHelper shoppingCartHelper, IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService)
        {
            _shoppingCartHelper = shoppingCartHelper;
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
        }
        public async Task<ShoppingCartItems> AddItemToCart(ShoppingCartAddItemModel model, int userId)
        {
            try
            {
                var cartList =  await _shoppingCartService.GetListWithShoppingCartItems_ShoppingCarts(x => x.User_Id == userId && x.Status && !x.Is_Deleted);
                var cart = cartList.FirstOrDefault();
                if (cart != null)
                {
                    var cartItems = cart.ShoppingCartItems;
                    if (cartItems != null && cartItems.Any(x => x.Product_Id == model.productId))
                    {
                        var cartProduct = await _shoppingCartItemService.Get(x => x.Product_Id == model.productId && x.ShoppingCart_Id == cart.Id);
                        cartProduct.Quantity += model.quantity;
                        return await _shoppingCartItemService.Update(cartProduct);
                    }
                    else
                    {
                        var itemCartItem = new ShoppingCartItems()
                        {
                            Product_Id = model.productId,
                            Quantity = model.quantity,
                            ShoppingCart_Id = cart.Id,
                        };
                        return await _shoppingCartItemService.Add(itemCartItem);

                    }
                }
                else
                {
                    var itemCart = new ShoppingCarts() {
                        User_Id = userId,
                        Status = true,
                        Is_Deleted = false,
                    };
                    var newCart = _shoppingCartService.Add(itemCart);
                    var itemCartItem = new ShoppingCartItems()
                    {
                        Product_Id = model.productId,
                        Quantity = model.quantity,
                        ShoppingCart_Id = newCart.Id,
                    };
                    return await _shoppingCartItemService.Add(itemCartItem);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
