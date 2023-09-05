using Application.Contract.DTOs.Token;
using Application.Contract.DTOs.User;
using Domain.Contract.Models.Users;
using System;
using System.Threading.Tasks;

namespace Application.User
{
    internal class UserMapper
    {
        internal LoginValidationDto LoginValidationDto(UserLoginModelResponse input)
        {
            return new LoginValidationDto
            {
                UserID = input.UserID,
                IsActive = input.IsActive,
                IsLogin = input.IsLogin,
                TokenCreate = input.TokenCreate,
                TokenDateValid = input.TokenDateValid,
                TokenIsValid = input.TokenIsValid,

            };
        }

        internal TokenJwtCreateDto TokenJwtCreateDto(UserLoginRequestDto user,HttpRequestDto http,int userID)
        {
            return new TokenJwtCreateDto
            {
                IPAddress=http.IPAddress,
                UserAgent=http.UserAgent,
                TokenGuid=Guid.NewGuid(),
                UserID= userID
            };
        }

        internal UserIsLoginResponseModel UserIsLoginResponseModel(UserLoginModelResponse input)
        {
            return new UserIsLoginResponseModel
            {
                UserID = input.UserID,
                IsLogin = true
            };
        }

        internal UserLoginModelRequest UserLoginModelRequest(UserLoginRequestDto input)
        {
            return new UserLoginModelRequest
            {
                Password = input.Password,
                UserName = input.UserName,
            };
        }

        internal UserLoginResponseDto UserLoginResponseDto(int userID, string token)
        {
            return new UserLoginResponseDto
            {
                UserID = userID,
                Token = token
            };
        }

        internal UserTokenModelRequest UserTokenModelRequest(string token, int userID, Guid tokenGuid)
        {
            return new UserTokenModelRequest
            {
                TokenGuid = tokenGuid,
                TokenStr = token,
                UserID = userID,
            };
        }
    }
}