using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserClaim;

namespace Domain.Contract.Repositories
{
    public interface IUserClaimRepository
    {
        Task<UserClaimSelectByIdResponseModel> SelectByID(UserClaimSelectByIdRequestModel model);
        Task<PageResponseModel<UserClaimSelectByFilterResponseModel>> SelectByFilter(UserClaimSelectByFilterRequestModel model);
        Task Create(UserClaimCreateRequestModel model);
        Task Delete(UserClaimDeleteRequestModel model);
    }
}
