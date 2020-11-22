using CicekSepeti.Business.Abstract.Helpers.HelperShopping;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CicekSepeti.WebUi.Controllers.ControllerShopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region services
        private readonly IShoppingCartItemHelper _shoppingCartItemHelper;
        private readonly IShoppingCartHelper _shoppingCartHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion 
        public CartController(IShoppingCartItemHelper shoppingCartItemHelper, IShoppingCartHelper shoppingCartHelper, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingCartHelper = shoppingCartHelper;
            _shoppingCartItemHelper = shoppingCartItemHelper;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<ShoppingCartItemModel> AddItem(ShoppingCartAddItemModel model)
        {
            try
            {
                var httpUser = _httpContextAccessor.HttpContext.User;
                var userId = Int32.Parse(httpUser.FindFirst(ClaimTypes.NameIdentifier).Value);
               ShoppingCartItems result = await _shoppingCartItemHelper.AddItemToCart(model,userId);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}