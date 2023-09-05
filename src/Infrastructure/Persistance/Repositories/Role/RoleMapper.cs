using Domain.Contract.Models.Base;
using Domain.Contract.Models.Role;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Role
{
    internal class RoleMapper
    {
        internal Domain.Role Role(RoleCreateRequestModel input)
        {
            return new Domain.Role
            {
                RoleName = input.RoleName,
            };
        }

        internal Domain.Role Role(RoleUpdateRequestModel input)
        {
            return new Domain.Role
            {
                RoleName = input.RoleName,
                RoleID = input.RoleID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal Domain.Role Role(RoleDeleteRequestModel input)
        {
            return new Domain.Role
            {
                RoleID = input.RoleID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal RoleCreateResponseModel RoleCreateResponseModel(EntityEntry<Domain.Role> input)
        {
            return new RoleCreateResponseModel
            {
                RoleName = (string)input.CurrentValues[nameof(Domain.Role.RoleName)],
                RoleID = (int)input.CurrentValues[nameof(Domain.Role.RoleID)],
                 ParentRoleID= (int?)input.CurrentValues[nameof(Domain.Role.ParentRoleID)]
                 
            };
        }

        internal RoleDeleteResponseModel RoleDeleteResponseModel(EntityEntry<Domain.Role> input)
        {
            return new RoleDeleteResponseModel
            {
                RoleID = (int)input.CurrentValues[nameof(Domain.Role.RoleID)],
            };
        }

        internal Expression<Func<Domain.Role, RoleSelectByFilterResponseModel>> RoleSelectByFilterResponseModel = (input) =>

           new RoleSelectByFilterResponseModel
           {
                RoleID= input.RoleID,
               RoleName = input.RoleName,
               ParentRoleID=input.ParentRoleID,
               ParentRoleName=input.ParentRole.RoleName,
               
           };
        internal Expression<Func<Domain.Role, RoleSelectByIdResponseModel>> RoleSelectByIdResponseModel = (input) =>

           new RoleSelectByIdResponseModel
           {
               RoleID = input.RoleID,
               RoleName = input.RoleName,
               CurrentRowVersion=input.CurrentRowVersion,
               ParentRoleID=input.ParentRoleID,
               
           };
        internal RoleUpdateResponseModel RoleUpdateResponseModel(EntityEntry<Domain.Role> input)
        {
            return new RoleUpdateResponseModel
            {
                RoleName = (string)input.CurrentValues[nameof(Domain.Role.RoleName)],
                RoleID = (int)input.CurrentValues[nameof(Domain.Role.RoleID)],
                ParentRoleID = (int?)input.CurrentValues[nameof(Domain.Role.ParentRoleID)],
            };
        }

        internal PageResponseModel<RoleSelectByFilterResponseModel> PageResponseModel_RoleSelectByFilterResponseModel(List<RoleSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<RoleSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }
    }
}
