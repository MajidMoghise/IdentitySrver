using Domain.Contract.Models.Base;
using Domain.Contract.Models.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Repositories
{
    public interface IClaimRepository
    {
        Task<ClaimSelectByIdResponseModel> SelectByID(ClaimSelectByIdRequestModel model);
        Task<PageResponseModel<ClaimSelectByFilterResponseModel>> SelectByFilter(ClaimSelectByFilterRequestModel model);
        Task<ClaimCreateResponseModel> Create(ClaimCreateRequestModel model);
        Task<ClaimUpdateResponseModel> Update(ClaimUpdateRequestModel model);
        Task<ClaimDeleteResponseModel> Delete(ClaimDeleteRequestModel model);
    }}
