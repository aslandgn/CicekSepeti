using CicekSepeti.Business.Abstract.Helpers.HelperUser;
using CicekSepeti.Dto.WebUiDtos.DtoUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CicekSepeti.WebUi.Controllers.ControllerUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region services
        private readonly IUserHelper _userHelper;
        #endregion
        public UserController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        [HttpPost("login")]
        public async Task<UserModel> Login(UserModel model)
        {
            try
            {
                return await _userHelper.Login(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}