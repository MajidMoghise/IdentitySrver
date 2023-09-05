using Domain.Contract.Models.Base;
using Domain.Contract.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Repositories
{
    public interface ISiteRepository
    {
        Task<SiteCreateResponseModel> Create(SiteCreateRequestModel model);
        Task<SiteUpdateResponseModel> Update(SiteUpdateRequestModel model);
        Task<SiteDeleteResponseModel> Delete(SiteDeleteRequestModel model);
        Task<SiteSelectByIdResponseModel> SelectById(SiteSelectByIdRequestModel model);
        Task<PageResponseModel<SiteSelectByFilterResponseModel>> SelectByFilter(SiteSelectByFilterRequestModel model);

    }
}
