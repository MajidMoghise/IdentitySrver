using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Repositories
{
    public interface IUserRepository
    {
        Task<PageResponseModel<UserSelectByFilterResponseModel>> SelectByFilter(UserSelectByFilterRequestModel filter);
        Task<UserSelectByIdResponseModel> SelectByID(UserSelectByIdRequestModel user);
        Task<UserLoginModelResponse> CheckUserNamePassword(UserLoginModelRequest model);
        Task CreateToken(UserTokenModelRequest model);
        Task<UserTokenValidModelResponse> TokenValid(UserTokenValidModelRequest model);
        Task CreateUser(UserCreateRequestModel model);
        Task UserIsActive(UserDisableRequestModel model);
        Task ResetPassword(UserResetPasswordRequestModel model);
        Task IsLogin(UserIsLoginResponseModel model);
    }
}
