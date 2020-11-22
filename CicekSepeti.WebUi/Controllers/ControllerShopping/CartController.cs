using CicekSepeti.Entity.Entities.SchemaShopping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CicekSepeti.Dto.WebUiDtos.DtoShopping;
using CicekSepeti.Business.Abstract.Helpers.HelperShopping;

namespace CicekSepeti.WebUi.Controllers.ControllerShopping
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region services
        private readonly IShoppingCartItemHelper _shoppingCartItemHelper;
        #endregion 
        public CartController(IShoppingCartItemHelper shoppingCartItemHelper)
        {
            _shoppingCartItemHelper = shoppingCartItemHelper;
        }
        [HttpPost]
        public Task<ShoppingCartItemModel> AddItem(ShoppingCartItemModel model)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}