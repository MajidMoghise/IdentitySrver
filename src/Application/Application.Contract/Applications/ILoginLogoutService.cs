using Application.Contract.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Applications
{
    public interface ILoginLogoutService
    {
        Task<UserLoginResponseDto> Login(UserLoginRequestDto user, HttpRequestDto httpDto);
        Task Logout(UserLogoutDto user);
    }
}
