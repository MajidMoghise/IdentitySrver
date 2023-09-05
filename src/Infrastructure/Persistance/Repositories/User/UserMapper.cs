using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Role;
using Domain.Contract.Models.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Persistance.Repositories.User
{
    internal class UserMapper
    {
        internal Domain.User User(UserCreateRequestModel input)
        {
            return new Domain.User
            {
                UserName = input.UserName,
                Password = input.UserPassword,
                IsActive = false
            };
        }

        internal Expression<Func<Domain.User, UserSelectByIdResponseModel>> UserSelectByIdResponseModel = (input) =>

           new UserSelectByIdResponseModel
           {
               UserID = input.UserID,
               UserName = input.UserName,
               IsActive = input.IsActive,
               IsLogin = input.IsLogin,
               LastLogin = input.LastLogin
           };
        internal  UserTokenValidModelResponse UserTokenValidModelResponse (Token input) =>

           new UserTokenValidModelResponse
           {
               UserID = input.UserID,
               TokenCreate = input.TokenCreate,
               TokenDateValid = input.TokenDateValid,
               TokenGuid = input.TokenGuid,
               TokenIsValid = input.TokenIsValid,
               TokenStr = input.TokenStr,

           };
       
        internal PageResponseModel<UserSelectByFilterResponseModel> PageResponseModel_UserSelectByFilterResponseModel(List<UserSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<UserSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }

        internal Token Token(UserTokenModelRequest model)
        {
            return new Token
            {
                UserID = model.UserID,
                TokenCreate = DateTime.Now,
                TokenDateValid = DateTime.Now.AddMinutes(10),
                TokenGuid = model.TokenGuid,
                TokenIsValid = true,
                TokenStr = model.TokenStr,
            };
        }

        internal Domain.User User(UserLoginModelRequest userLogin)
        {
            return new Domain.User
            {
                Password = userLogin.Password,
                UserName = userLogin.UserName,
            };
        }

        internal Domain.User User(UserIsLoginResponseModel input)
        {
            return new Domain.User
            {
                UserID = input.UserID,
                IsLogin = input.IsLogin,
            };
        }

        internal Domain.User User(UserDisableRequestModel input)
        {
            return new Domain.User
            {
                UserID = input.UserID,
                IsActive = input.IsActive,
            };
        }

        internal Domain.User User(UserResetPasswordRequestModel input)
        {
            return new Domain.User
            {
                UserID = input.UserID,
                Password = input.Password,
            };
        }

        internal UserCreateResponseModel UserCreateResponseModel(EntityEntry<Domain.User> input)
        {
            return new UserCreateResponseModel
            {
                UserID = (int)input.CurrentValues[nameof(Domain.User.UserID)]
            };
        }

        internal Expression<Func<Domain.User, UserLoginModelResponse>> UserLoginModelResponse = (input) =>

          new UserLoginModelResponse
          {
              IsActive = input.IsActive,
              IsLogin = input.IsLogin,
              TokenDateValid = input.Token.TokenDateValid,
              TokenCreate = input.Token.TokenCreate,
              TokenIsValid = input.Token.TokenIsValid,
              UserID = input.UserID
          };
        internal Expression<Func<Domain.User, UserSelectByFilterResponseModel>> UserSelectByFilterResponseModel = (input) =>

          new UserSelectByFilterResponseModel
          {
              IsActive = input.IsActive,
              IsLogin = input.IsLogin,
              LastLogin = input.LastLogin,
              UserName = input.UserName,
              UserID = input.UserID
          };


    }
}
