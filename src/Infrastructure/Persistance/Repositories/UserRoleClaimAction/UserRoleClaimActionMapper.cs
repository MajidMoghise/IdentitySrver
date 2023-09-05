using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserRoleClaimAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.UserRoleClaimAction
{
    internal class UserRoleClaimActionMapper
    {
        internal Domain.UserRoleClaimAction UserRoleClaimAction(UserRoleClaimActionCreateRequestModel input)
        {
            return new Domain.UserRoleClaimAction
            {
                ActionID = input.ActionID,
                ClaimID=input.ClaimID,
                RoleID=input.RoleID,
                UserID=input.UserID,
                
            };
        }

        internal Domain.UserRoleClaimAction UserRoleClaimAction(UserRoleClaimActionDeleteRequestModel input)
        {
            return new Domain.UserRoleClaimAction
            {
                ActionID = input.ActionID,
                UserID=input.UserID,
                RoleID=input.RoleID,
                ClaimID=input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

       
        internal Expression<Func<Domain.UserRoleClaimAction, UserRoleClaimActionSelectResponseModel>> UserRoleClaimActionSelectByFilterResponseModel = (input) =>

           new UserRoleClaimActionSelectResponseModel
           {
               UserID = input.UserID,
               UserName=input.User.UserName,
               CalimName = input.Claim.ClaimName,
               ActionID=input.ActionID,
               ActionName=input.Action.ActionName,
               AreaID = input.Action.Controller.Area.AreaID,
               AreaName=input.Action.Controller.Area.AreaName,
               ControllerID=input.Action.ControllerID,
               ControllerName=input.Action.Controller.ControllerName,
               ClaimID=input.ClaimID,
               RoleID=input.RoleID,
               RoleName=input.Role.RoleName,
               ParentRoleID=input.Role.ParentRoleID,
               ParentRoleName=input.Role.ParentRole.RoleName,
               SiteID=input.Action.Controller.Area.SiteID,
               SiteName=input.Action.Controller.Area.Site.SiteName
           };
       

        internal PageResponseModel<UserRoleClaimActionSelectResponseModel> PageResponseModel_UserRoleClaimActionSelectByFilterResponseModel(List<UserRoleClaimActionSelectResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<UserRoleClaimActionSelectResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }
    }
}
