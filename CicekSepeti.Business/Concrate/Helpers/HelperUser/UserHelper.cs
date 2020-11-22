using AutoMapper;
using CicekSepeti.Business.Abstract.Helpers.HelperUser;
using CicekSepeti.Business.Abstract.Services.ServiceUser;
using CicekSepeti.Dto.WebUiDtos.DtoUser;
using CicekSepeti.Entity.Entities.SchemaUser;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Helpers.HelperUser
{
    public class UserHelper : IUserHelper
    {
        #region services
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        #endregion
        public UserHelper(IUserService userService, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<UserModel> Login(UserModel model)
        {
            try
            {
                var user = await _userService.Get(x => x.Name == model.name && x.Password == model.password);

                // return null if user not found
                if (user == null) return null;

                // authentication successful so generate jwt token
                var token = generateJwtToken(user);
                var userModel = _mapper.Map<Users, UserModel>(user);
                userModel.token = token;
                return userModel;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
