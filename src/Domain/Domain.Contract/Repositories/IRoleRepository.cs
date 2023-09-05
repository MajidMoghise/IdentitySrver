using Domain.Contract.Models.Base;
using Domain.Contract.Models.Role;

namespace Domain.Contract.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleSelectByIdResponseModel> SelectByID(RoleSelectByIdRequestModel model);
        Task<PageResponseModel<RoleSelectByFilterResponseModel>> SelectByFilter(RoleSelectByFilterRequestModel model);
        Task<RoleCreateResponseModel> Create(RoleCreateRequestModel model);
        Task<RoleUpdateResponseModel> Update(RoleUpdateRequestModel model);
        Task<RoleDeleteResponseModel> Delete(RoleDeleteRequestModel model);
    }
}
