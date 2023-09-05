using Application.Contract.DTOs;
using Application.Contract.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Applications
{
    public interface IUserTokenService
    {
        ResponseModel Accessbility(UserTokenVM userLogin);
        Task<ResponseModel<UserTokenVM>> GetUserToken(UserLoginRequestDto userLogin);
        Task<ResponseModel> ExpiredToken(UserTokenVM userLogin);
    }
}
