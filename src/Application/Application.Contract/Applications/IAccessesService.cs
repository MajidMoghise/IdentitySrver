using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Accesses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contract.Applications
{
    public interface IAccessesService
    {
         Task<ClaimCreateResponseDto> CreateClaim(ClaimCreateRequestDto dto);
         Task<ClaimDeleteResponseDto> DeleteClaim(ClaimDeleteRequestDto dto);
         Task<ClaimUpdateResponseDto> UpdateClaim(ClaimUpdateRequestDto dto);
         Task<RoleCreateResponseDto> CreateRole(RoleCreateRequestDto dto);
         Task<RoleDeleteResponseDto> DeleteRole(RoleDeleteRequestDto dto);
         Task<RoleUpdateResponseDto> UpdateRole(RoleUpdateRequestDto dto);
         Task<PageResponseDto<UserRoleClaimActionSelectResponseDto>> SelectAccess(UserRoleClaimActionSelectRequestDto Dto);
         Task CreateAccess(UserRoleClaimActionCreateRequestDto Dto);
         Task DeleteAccess(UserRoleClaimActionDeleteRequestDto Dto);

    }
}
