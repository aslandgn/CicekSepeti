using AutoMapper;
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
    public class ShoppingCartHelper : IShoppingCartHelper
    {
        #region services
        private readonly IShoppingCartItemService _shoppingCartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        #endregion
        public ShoppingCartHelper(IShoppingCartItemService shoppingCartItemService, IShoppingCartService shoppingCartService, IMapper mapper, IProductService productService)
        {
            _shoppingCartItemService = shoppingCartItemService;
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ShoppingCartDto> ShowCart(int userId)
        {
            try
            {
                var cartList = await _shoppingCartService.GetListWithShoppingCartItems_ShoppingCarts(x => x.User_Id == userId && x.Status && !x.Is_Deleted);
                var cart = cartList.FirstOrDefault();
                if (cart == null)
                {
                    return new ShoppingCartDto();
                }
                else
                {
                    return _mapper.Map<ShoppingCarts, ShoppingCartDto>(cart);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ClearCart(long cartId)
        {
            try
            {
                var cartItems = await _shoppingCartItemService.GetList(x => x.ShoppingCart_Id == cartId);
                _shoppingCartItemService.Delete(cartItems);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ShoppingCartDto> CompleteShopping(long cartId)
        {
            try
            {
                //var cartItems = await _shoppingCartItemService.GetList(x => x.ShoppingCart_Id == cartId);
                var products = await _productService.GetListWithShoppingCartItems_Products(x => x.ShoppingCartItems.Any(y => y.ShoppingCart_Id == cartId));
                decimal total = 0;
                if (!products.Any())
                {
                    throw new Exception("no product to buy");
                }
                else
                {
                    products.ForEach(product =>
                    {
                        if (product.InStock == 0)
                        {
                            throw new Exception("no stock");

                        }
                        else if (product.InStock < product.ShoppingCartItems.Where(x => x.ShoppingCart_Id == cartId).Sum(x => x.Quantity))
                        {
                            throw new Exception("not enough stock");
                        }
                        else
                        {
                            var items = product.ShoppingCartItems.Where(x => x.ShoppingCart_Id == cartId).FirstOrDefault();
                            product.InStock -= items.Quantity;
                            total += product.Price * items.Quantity;
                        }
                    });
                    await _productService.Update(products);
                    var cart = await _shoppingCartService.Get(x => x.Id == cartId);
                    cart.Total = total;
                    cart.Status = false;
                    var updatedCart = await _shoppingCartService.Update(cart);
                    return _mapper.Map<ShoppingCarts, ShoppingCartDto>(updatedCart);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
