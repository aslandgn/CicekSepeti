using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CicekSepeti.Business.Abstract.Helpers.HelperShopping;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CicekSepeti.WebUi.Controllers.ControllerShopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        #region services
        private readonly IShoppingCartItemHelper _shoppingCartItemHelper;
        private readonly IShoppingCartHelper _shoppingCartHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        #endregion 
        public ShoppingCartItemController(IShoppingCartItemHelper shoppingCartItemHelper, IShoppingCartHelper shoppingCartHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _shoppingCartHelper = shoppingCartHelper;
            _shoppingCartItemHelper = shoppingCartItemHelper;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ShoppingCartItemDto> AddItem(ShoppingCartAddItemDto dto)
        {
            try
            {
                var httpUser = _httpContextAccessor.HttpContext.User;
                var userId = Int32.Parse(httpUser.FindFirst(ClaimTypes.NameIdentifier).Value);
                ShoppingCartItems result = await _shoppingCartItemHelper.AddItemToCart(dto, userId);
                return _mapper.Map<ShoppingCartItems, ShoppingCartItemDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ShoppingCartItemDto> ChangeQuantity(ShoppingCartItemDto dto)
        {
            try
            {
                return await _shoppingCartItemHelper.ChangeQuantity(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task DeleteItem(ShoppingCartItemDto dto)
        {
            try
            {
                await _shoppingCartItemHelper.Delete(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}