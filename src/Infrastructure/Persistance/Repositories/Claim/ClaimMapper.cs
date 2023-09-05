using Domain.Contract.Models.Base;
using Domain.Contract.Models.Claim;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Claim
{
    internal class ClaimMapper
    {
        internal Domain.Claim Claim(ClaimCreateRequestModel input)
        {
            return new Domain.Claim
            {
                ClaimName = input.ClaimName,
            };
        }

        internal Domain.Claim Claim(ClaimUpdateRequestModel input)
        {
            return new Domain.Claim
            {
                ClaimName = input.ClaimName,
                ClaimID = input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion,
                ParentClaimID=input.ParentClaimID,
            };
        }

        internal Domain.Claim Claim(ClaimDeleteRequestModel input)
        {
            return new Domain.Claim
            {
                ClaimID = input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal ClaimCreateResponseModel ClaimCreateResponseModel(EntityEntry<Domain.Claim> input)
        {
            return new ClaimCreateResponseModel
            {
                ClaimName = (string)input.CurrentValues[nameof(Domain.Claim.ClaimName)],
                ClaimID = (int)input.CurrentValues[nameof(Domain.Claim.ClaimID)],
                 ParentClaimID= (int)input.CurrentValues[nameof(Domain.Claim.ParentClaimID)],             
            };
        }

        internal ClaimDeleteResponseModel ClaimDeleteResponseModel(EntityEntry<Domain.Claim> input)
        {
            return new ClaimDeleteResponseModel
            {
                ClaimID = (int)input.CurrentValues[nameof(Domain.Claim.ClaimID)],
            };
        }

        internal Expression<Func<Domain.Claim, ClaimSelectByFilterResponseModel>> ClaimSelectByFilterResponseModel = (input) =>

           new ClaimSelectByFilterResponseModel
           {
                ClaimID= input.ClaimID,
               ClaimName = input.ClaimName,
               ParentClaimID=input.ParentClaimID,
               ParentClaimName=input.ParentClaim.ClaimName,
               
           };
        internal Expression<Func<Domain.Claim, ClaimSelectByIdResponseModel>> ClaimSelectByIdResponseModel = (input) =>

           new ClaimSelectByIdResponseModel
           {
               ClaimID = input.ClaimID,
               ClaimName = input.ClaimName,
               CurrentRowVersion=input.CurrentRowVersion,
              ParentClaimID=input.ParentClaimID 
           };
        internal ClaimUpdateResponseModel ClaimUpdateResponseModel(EntityEntry<Domain.Claim> input)
        {
            return new ClaimUpdateResponseModel
            {
                ClaimName = (string)input.CurrentValues[nameof(Domain.Claim.ClaimName)],
                ClaimID = (int)input.CurrentValues[nameof(Domain.Claim.ClaimID)],
                ParentClaimID = (int)input.CurrentValues[nameof(Domain.Claim.ParentClaimID)],
            };
        }

        internal PageResponseModel<ClaimSelectByFilterResponseModel> PageResponseModel_ClaimSelectByFilterResponseModel(List<ClaimSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<ClaimSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }
    }
}
