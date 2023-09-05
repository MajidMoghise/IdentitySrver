using Application.Contract.Applications;
using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Accesses;
using Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accesses
{
    internal class AccessesService : IAccessesService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleClaimActionRepository _userRoleClaimActionRepository;
        private readonly AccessMapper _mapper;
        public AccessesService
            (IClaimRepository claimRepository, 
             IRoleRepository roleRepository, 
             IUserRoleClaimActionRepository userRoleClaimActionRepository)
        {
            _claimRepository = claimRepository;
            _mapper = new AccessMapper();
            _roleRepository = roleRepository;
            _userRoleClaimActionRepository = userRoleClaimActionRepository;
        }

        public Task<ClaimCreateResponseDto> CreateClaim(ClaimCreateRequestDto dto)
        {
            var requestModel = _mapper.ClaimCreateRequestModel(input: dto);
            var resultDb = _claimRepository.Create(requestModel).Result;
            var result = _mapper.ClaimCreateResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task<ClaimDeleteResponseDto> DeleteClaim(ClaimDeleteRequestDto dto)
        {
            var requestModel = _mapper.ClaimDeleteRequestModel(input: dto);
            var resultDb = _claimRepository.Delete(requestModel).Result;
            var result = _mapper.ClaimDeleteResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task<ClaimUpdateResponseDto> UpdateClaim(ClaimUpdateRequestDto dto)
        {
            var requestModel = _mapper.ClaimUpdateRequestModel(input: dto);
            var resultDb = _claimRepository.Update(requestModel).Result;
            var result = _mapper.ClaimUpdateResponseDto(input: resultDb);
            return Task.FromResult(result);
        }
          public Task<RoleCreateResponseDto> CreateRole(RoleCreateRequestDto dto)
        {
            var requestModel = _mapper.RoleCreateRequestModel(input: dto);
            var resultDb = _roleRepository.Create(requestModel).Result;
            var result = _mapper.RoleCreateResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task<RoleDeleteResponseDto> DeleteRole(RoleDeleteRequestDto dto)
        {
            var requestModel = _mapper.RoleDeleteRequestModel(input: dto);
            var resultDb = _roleRepository.Delete(requestModel).Result;
            var result = _mapper.RoleDeleteResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task<RoleUpdateResponseDto> UpdateRole(RoleUpdateRequestDto dto)
        {
            var requestModel = _mapper.RoleUpdateRequestModel(input: dto);
            var resultDb = _roleRepository.Update(requestModel).Result;
            var result = _mapper.RoleUpdateResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task<PageResponseDto<UserRoleClaimActionSelectResponseDto>> SelectAccess(UserRoleClaimActionSelectRequestDto dto)
        {
            var requestModel = _mapper.UserRoleClaimActionSelectRequestModel(input: dto);
            var resultDb = _userRoleClaimActionRepository.Select(requestModel).Result;
            var result = _mapper.PageResponseDto_UserRoleClaimActionSelectResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task CreateAccess(UserRoleClaimActionCreateRequestDto dto)
        {
            var requestModel = _mapper.UserRoleClaimActionCreateRequestModel(input: dto);
            var resultDb = _userRoleClaimActionRepository.Create(requestModel).GetAwaiter();
            var result = _mapper.UserRoleClaimActionCreateResponseDto(input: resultDb);
            return Task.FromResult(result);
        }

        public Task DeleteAccess(UserRoleClaimActionDeleteRequestDto dto)
        {
            var requestModel = _mapper.UserRoleClaimActionDeleteRequestModel(input: dto);
            var resultDb = _userRoleClaimActionRepository.Delete(requestModel).GetAwaiter();
            return Task.CompletedTask;
        }
    }
}
