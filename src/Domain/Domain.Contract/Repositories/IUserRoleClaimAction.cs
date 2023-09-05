using Domain.Contract.Models.Base;
using Domain.Contract.Models.Role;
using Domain.Contract.Models.UserRoleClaimAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Repositories
{
    public interface IUserRoleClaimActionRepository
    {
        Task<PageResponseModel<UserRoleClaimActionSelectResponseModel>> Select(UserRoleClaimActionSelectRequestModel model);
        Task Create(UserRoleClaimActionCreateRequestModel model);
        Task Delete(UserRoleClaimActionDeleteRequestModel model);
        Task<bool> UserAccess(UserRoleClaimActionSelectRequestModel model);


    }
}
