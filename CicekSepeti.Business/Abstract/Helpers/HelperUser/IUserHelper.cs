using CicekSepeti.Dto.WebUiDtos.DtoUser;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Helpers.HelperUser
{
    public interface IUserHelper
    {
        Task<UserModel> Login(UserModel model);
    }
}
