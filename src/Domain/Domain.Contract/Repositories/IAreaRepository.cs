using Domain.Contract.Models.Area;

namespace Domain.Contract.Repositories
{
    public interface IAreaRepository
    {
        Task<AreaCreateResponseModel> Create(AreaCreateRequestModel model);
        Task<AreaUpdateResponseModel> Update(AreaUpdateRequestModel model);
        Task<AreaDeleteResponseModel> Delete(AreaDeleteRequestModel model);
        Task<AreaSelectByIdResponseModel> SelectById(AreaSelectByIdRequestModel model);
    
    }
}
