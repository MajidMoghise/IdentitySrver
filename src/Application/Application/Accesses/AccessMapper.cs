using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Accesses;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Claim;
using Domain.Contract.Models.Role;
using Domain.Contract.Models.UserRoleClaimAction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Accesses
{
    internal class AccessMapper
    {
        internal ClaimCreateRequestModel ClaimCreateRequestModel(ClaimCreateRequestDto input)
        {
            return new ClaimCreateRequestModel
            {
                ClaimName = input.ClaimName,
                ParentClaimID = input.ParentClaimID,
            };
        }

        internal ClaimCreateResponseDto ClaimCreateResponseDto(ClaimCreateResponseModel input)
        {
            return new ClaimCreateResponseDto
            {
                ClaimID = input.ClaimID,
                ClaimName = input.ClaimName,
                ParentClaimID = input.ParentClaimID
            };
        }

        internal ClaimDeleteRequestModel ClaimDeleteRequestModel(ClaimDeleteRequestDto input)
        {
            return new ClaimDeleteRequestModel
            {
                ClaimID = input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal ClaimDeleteResponseDto ClaimDeleteResponseDto(ClaimDeleteResponseModel input)
        {
            return new ClaimDeleteResponseDto
            {
                ClaimID = input.ClaimID
            };
        }

        internal ClaimUpdateRequestModel ClaimUpdateRequestModel(ClaimUpdateRequestDto input)
        {
            return new ClaimUpdateRequestModel
            {
                ClaimID = input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion,
                ClaimName = input.ClaimName,
                ParentClaimID = input.ParentClaimID,
            };
        }

        internal ClaimUpdateResponseDto ClaimUpdateResponseDto(ClaimUpdateResponseModel input)
        {
            return new Contract.DTOs.Accesses.ClaimUpdateResponseDto
            {
                ParentClaimID = input.ParentClaimID,
                ClaimName = input.ClaimName,
                ClaimID = input.ClaimID,
            };
        }

        internal RoleCreateRequestModel RoleCreateRequestModel(RoleCreateRequestDto input)
        {
            return new RoleCreateRequestModel
            {
                RoleName = input.RoleName,
                ParentRoleID = input.ParentRoleID,
            };
        }

        internal RoleCreateResponseDto RoleCreateResponseDto(RoleCreateResponseModel input)
        {
            return new RoleCreateResponseDto
            {
                RoleName = input.RoleName,
                ParentRoleID = input.ParentRoleID,
                RoleID = input.RoleID
            };
        }

        internal RoleDeleteRequestModel RoleDeleteRequestModel(RoleDeleteRequestDto input)
        {
            return new RoleDeleteRequestModel
            {
                RoleID = input.RoleID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal RoleDeleteResponseDto RoleDeleteResponseDto(RoleDeleteResponseModel input)
        {
            return new RoleDeleteResponseDto
            {
                RoleID = input.RoleID
            };
        }

        internal RoleUpdateRequestModel RoleUpdateRequestModel(RoleUpdateRequestDto input)
        {
            return new RoleUpdateRequestModel
            {
                RoleID = input.RoleID,
                CurrentRowVersion = input.CurrentRowVersion,
                ParentRoleID = input.ParentRoleID,
                RoleName = input.RoleName,
            };
        }

        internal RoleUpdateResponseDto RoleUpdateResponseDto(RoleUpdateResponseModel input)
        {
            return new RoleUpdateResponseDto
            {
                RoleName = input.RoleName,
                ParentRoleID = input.ParentRoleID,
                RoleID = input.RoleID,
            };
        }

        internal UserRoleClaimActionCreateRequestModel UserRoleClaimActionCreateRequestModel(UserRoleClaimActionCreateRequestDto input)
        {
            return new UserRoleClaimActionCreateRequestModel
            {
                UserID = input.UserID,
                RoleID = input.RoleID,
                ClaimID = input.ClaimID,
                ActionID = input.ActionID,
            };
        }

        internal object UserRoleClaimActionCreateResponseDto(object input)
        {
            throw new NotImplementedException();
        }

        internal UserRoleClaimActionDeleteRequestModel UserRoleClaimActionDeleteRequestModel(object input)
        {
            throw new NotImplementedException();
        }



        internal UserRoleClaimActionSelectRequestModel UserRoleClaimActionSelectRequestModel(UserRoleClaimActionSelectRequestDto input)
        {
            return new UserRoleClaimActionSelectRequestModel
            {
                RoleID = input.RoleID,
                ActionID = input.ActionID,
                ClaimID = input.RoleID,
                UserID = input.UserID
            };
        }

        internal PageResponseDto<UserRoleClaimActionSelectResponseDto> PageResponseDto_UserRoleClaimActionSelectResponseDto(PageResponseModel<UserRoleClaimActionSelectResponseModel> input)
        {
            return new PageResponseDto<UserRoleClaimActionSelectResponseDto>
            {
                Datas = input.Datas.Select(s => new UserRoleClaimActionSelectResponseDto
                {
                    ActionID = s.ActionID,
                    ActionName = s.ActionName,
                    AreaID = s.ActionID,
                    AreaName = s.AreaName,
                    CalimName = s.ActionName,
                    ClaimID = s.ClaimID,
                    ControllerID = s.ActionID,
                    ControllerName = s.ControllerName,
                    RoleID = s.RoleID,
                    RoleName = s.RoleName,
                    ParentRoleID = s.ParentRoleID,
                    ParentRoleName = s.ParentRoleName,
                    SiteID = s.SiteID,
                    SiteName = s.SiteName,
                    UserID = s.UserID,
                    UserName = s.UserName,
                }).ToList(),
                PageIndex=input.PageIndex,
                TotalObjectCount=input.TotalObjectCount,
                TotalPageCount = input.TotalPageCount   
            };
        }
    }
}
