using Domain.Contract.Models.Action;
using Domain.Contract.Models.Site;

namespace Domain.Contract.Repositories
{
    public interface IActionRepository
    {
        Task<ActionCreateResponseModel> Create(ActionCreateRequestModel model);
        Task<ActionUpdateResponseModel> Update(ActionUpdateRequestModel model);
        Task<ActionDeleteResponseModel> Delete(ActionDeleteRequestModel model);
        Task<ActionSelectByIdResponseModel> SelectById(ActionSelectByIdRequestModel model);

    }
}
