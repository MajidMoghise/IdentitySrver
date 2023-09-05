using Application.Contract.Applications;
using Application.Contract.DTOs.User;
using Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class LoginLogoutValidationService : ILoginLogoutValidationService
    {
       public Task LoginValidation(LoginValidationDto dto)
        {
            if (dto is null)
            {
                throw new BusinessException("UserName Or Password Is Not Correct");
            }
            if (dto.IsLogin)
            {
                throw new BusinessException("Your Account Is Login. Do you want login again? ");
            }
            if (!dto.IsActive)
            {
                throw new BusinessException("Your account is not valid.");
            }
            return Task.CompletedTask;
        }
    }
}
