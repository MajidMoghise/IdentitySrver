using Domain.Contract.Models.Controller;
using Domain.Contract.Models.Site;

namespace Domain.Contract.Repositories
{
    public interface IControllerRepository
    {
        Task<ControllerCreateResponseModel> Create(ControllerCreateRequestModel model);
        Task<ControllerUpdateResponseModel> Update(ControllerUpdateRequestModel model);
        Task<ControllerDeleteResponseModel> Delete(ControllerDeleteRequestModel model);
        Task<ControllerSelectByIdResponseModel> SelectById(ControllerSelectByIdRequestModel model);

    }
}
