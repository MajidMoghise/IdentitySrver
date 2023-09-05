using Application.Contract.Applications;
using Application.Contract.DTOs;
using Application.Contract.DTOs.User;
using System.Threading.Tasks;

namespace Application.User
{

    public class UserTokenService : IUserTokenService
    {

        public UserTokenService()
        {

        }
        public ResponseModel Accessbility(UserTokenVM userLogin)
        {
            return null;
        }
        public async Task<ResponseModel<UserTokenVM>> GetUserToken(UserLoginRequestDto userLogin)
        {
            return null;
        }
        public async Task<ResponseModel> ExpiredToken(UserTokenVM userLogin)
        {
            return null;
        }

    }

}
