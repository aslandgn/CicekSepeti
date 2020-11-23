using CicekSepeti.Business.Abstract.Helpers.HelperShopping;
using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.Business.Abstract.Services.ServiceShopping;
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
        private readonly IProductService _productService;
        #endregion
        public ShoppingCartItemHelper(IShoppingCartHelper shoppingCartHelper, IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService, IProductService productService)
        {
            _shoppingCartHelper = shoppingCartHelper;
            _shoppingCartItemService = shoppingCartItemService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<ShoppingCartItems> AddItemToCart(ShoppingCartAddItemDto dto, int userId)
        {
            try
            {
                var cartList = await _shoppingCartService.GetListWithShoppingCartItems_ShoppingCarts(x => x.User_Id == userId && x.Status && !x.Is_Deleted);
                var cart = cartList.FirstOrDefault();
                var product = await _productService.Get(x => x.Id == dto.productId);
                if (product.InStock < dto.quantity)
                {
                    throw new Exception("no stock");
                }
                else
                {
                    if (cart != null)
                    {
                        var cartItems = cart.ShoppingCartItems;
                        if (cartItems != null && cartItems.Any(x => x.Product_Id == dto.productId))
                        {
                            var cartProduct = await _shoppingCartItemService.Get(x => x.Product_Id == dto.productId && x.ShoppingCart_Id == cart.Id);
                            cartProduct.Quantity += dto.quantity;
                            if (product.InStock < cartProduct.Quantity)
                            {
                                throw new Exception("no stock");

                            }
                            return await _shoppingCartItemService.Update(cartProduct);

                        }
                        else
                        {
                            var itemCartItem = new ShoppingCartItems()
                            {
                                Product_Id = dto.productId,
                                Quantity = dto.quantity,
                                ShoppingCart_Id = cart.Id,
                            };
                            return await _shoppingCartItemService.Add(itemCartItem);

                        }
                    }
                    else
                    {
                        var itemCart = new ShoppingCarts()
                        {
                            User_Id = userId,
                            Status = true,
                            Is_Deleted = false,
                        };
                        var newCart = await _shoppingCartService.Add(itemCart);
                        var itemCartItem = new ShoppingCartItems()
                        {
                            Product_Id = dto.productId,
                            Quantity = dto.quantity,
                            ShoppingCart_Id = newCart.Id,
                        };
                        return await _shoppingCartItemService.Add(itemCartItem);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ShoppingCartItemDto> ChangeQuantity(ShoppingCartItemDto dto)
        {
            try
            {
                var cartItem = await _shoppingCartItemService.Get(x => x.Product_Id == dto.productId && x.ShoppingCart_Id == dto.cartId);
                if (cartItem == null)
                {
                    throw new Exception("can not find");
                }
                var product = await _productService.Get(x => x.Id == dto.productId);
                if (product.InStock < dto.quantity)
                {
                    cartItem.Quantity = (short)product.InStock;
                    await _shoppingCartItemService.Update(cartItem);
                    throw new Exception("no stock");
                }
                cartItem.Quantity = dto.quantity;
                await _shoppingCartItemService.Update(cartItem);
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(ShoppingCartItemDto dto)
        {
            try
            {
                var cartItem = await _shoppingCartItemService.Get(x => x.Product_Id == dto.productId && x.ShoppingCart_Id == dto.cartId);
                if (cartItem == null)
                {
                    throw new Exception("can not find");
                }
                _shoppingCartItemService.Delete(cartItem);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
