using Application.Contract.Applications;
using Application.Contract.DTOs.User;
using Application.Helper;
using Domain.Contract.Models.UserClaim;
using Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class LoginLogoutService : ILoginLogoutService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserMapper _mapper;
        private readonly ILoginLogoutValidationService _validationService;
        private readonly ITokenService _tokenService;
        public LoginLogoutService
            (IUserRepository userRepository,
             IUnitOfWork unitOfWork,
             ILoginLogoutValidationService validationService,
             ITokenService tokenService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = new UserMapper();
            _validationService = validationService;
            _tokenService = tokenService;
        }
        public Task<UserLoginResponseDto> Login(UserLoginRequestDto user,HttpRequestDto httpDto)
        {
            var userLoginModelRequest = _mapper.UserLoginModelRequest(user);
            var resultCheckPassword= _userRepository.CheckUserNamePassword(userLoginModelRequest).Result;
            var validatDto = _mapper.LoginValidationDto(resultCheckPassword);
            _validationService.LoginValidation(validatDto);
            var createJwt = _mapper.TokenJwtCreateDto(user, httpDto, resultCheckPassword.UserID);
            var resultToken = _tokenService.CreateJwts(createJwt).Result;
            var tokenModel = _mapper.UserTokenModelRequest(token: resultToken, userID: resultCheckPassword.UserID, createJwt.TokenGuid);
            _unitOfWork.BeginTransaction();
            _userRepository.CreateToken(tokenModel);
            var userIsLogin = _mapper.UserIsLoginResponseModel(input: resultCheckPassword);
            _userRepository.IsLogin(userIsLogin);
            _unitOfWork.Commit();
            var result = _mapper.UserLoginResponseDto(userID: resultCheckPassword.UserID, token: resultToken);
            return Task.FromResult(result);
          
        }

        public Task Logout(UserLogoutDto user)
        {
            throw new NotImplementedException();
            //get UserID And Toke From Token Table
            //Update IsActive From Token Table To False
            //update IsLogin From User To False
        }
    }
}
