using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.UserRole
{
    internal class UserRoleMapper
    {
        internal Domain.UserRole UserRole(UserRoleCreateRequestModel input)
        {
            return new Domain.UserRole
            {
                RoleID=input.RoleID,
                UserID=input.UserID,
                
            };
        }

        internal Domain.UserRole UserRole(UserRoleDeleteRequestModel input)
        {
            return new Domain.UserRole
            {
                UserID=input.UserID,
                RoleID=input.RoleID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

       
        internal Expression<Func<Domain.UserRole, UserRoleSelectByFilterResponseModel>> UserRoleSelectByFilterResponseModel = (input) =>

           new UserRoleSelectByFilterResponseModel
           {
               UserID = input.UserID,
               UserName=input.User.UserName,
               RoleID=input.RoleID,
               RoleName=input.Role.RoleName,
               ParentRoleID=input.Role.ParentRoleID,
               ParentRoleName=input.Role.ParentRole.RoleName,
           };
       

        internal PageResponseModel<UserRoleSelectByFilterResponseModel> PageResponseModel_UserRoleSelectByFilterResponseModel(List<UserRoleSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<UserRoleSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }

        
        internal UserRoleSelectByIdResponseModel UserRoleSelectByIdResponseModel(Domain.UserRole input)
        {
            return new UserRoleSelectByIdResponseModel
            {
                RoleID = input.RoleID,
                RowCurrentVersion = input.CurrentRowVersion,
                UserID = input.UserID
            };
        }
    }
}
