using AutoMapper;
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
    public class ShoppingCartController : ControllerBase
    {
        #region services
        private readonly IShoppingCartItemHelper _shoppingCartItemHelper;
        private readonly IShoppingCartHelper _shoppingCartHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        #endregion 
        public ShoppingCartController(IShoppingCartItemHelper shoppingCartItemHelper, IShoppingCartHelper shoppingCartHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _shoppingCartHelper = shoppingCartHelper;
            _shoppingCartItemHelper = shoppingCartItemHelper;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<ShoppingCartDto> ShowCart()
        {
            try
            {
                var httpUser = _httpContextAccessor.HttpContext.User;
                var userId = Int32.Parse(httpUser.FindFirst(ClaimTypes.NameIdentifier).Value);
                return _shoppingCartHelper.ShowCart(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{cartId}")]
        public Task<ShoppingCartDto> CompleteCart(long cartId)
        {
            try
            {
                return _shoppingCartHelper.CompleteShopping(cartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task CleanCart(long cartId)
        {
            try
            {
                await _shoppingCartHelper.ClearCart(cartId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}