using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserRole;

namespace Domain.Contract.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRoleSelectByIdResponseModel> SelectByID(UserRoleSelectByIdRequestModel model);
        Task<PageResponseModel<UserRoleSelectByFilterResponseModel>> SelectByFilter(UserRoleSelectByFilterRequestModel model);
        Task Create(UserRoleCreateRequestModel model);
        Task Delete(UserRoleDeleteRequestModel model);
    }
}
