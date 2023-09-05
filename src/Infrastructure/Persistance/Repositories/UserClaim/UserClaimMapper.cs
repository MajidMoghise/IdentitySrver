using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.UserClaim
{
    internal class UserClaimMapper
    {
        internal Domain.UserClaim UserClaim(UserClaimCreateRequestModel input)
        {
            return new Domain.UserClaim
            {
                ClaimID=input.ClaimID,
                UserID=input.UserID,
                
            };
        }

        internal Domain.UserClaim UserClaim(UserClaimDeleteRequestModel input)
        {
            return new Domain.UserClaim
            {
                UserID=input.UserID,
                ClaimID=input.ClaimID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

       
        internal Expression<Func<Domain.UserClaim, UserClaimSelectByFilterResponseModel>> UserClaimSelectByFilterResponseModel = (input) =>

           new UserClaimSelectByFilterResponseModel
           {
               UserID = input.UserID,
               UserName=input.User.UserName,
               ClaimID=input.ClaimID,
               ClaimName=input.Claim.ClaimName,
               ParentClaimID=input.Claim.ParentClaimID,
               ParentClaimName=input.Claim.ParentClaim.ClaimName,
           };
       

        internal PageResponseModel<UserClaimSelectByFilterResponseModel> PageResponseModel_UserClaimSelectByFilterResponseModel(List<UserClaimSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<UserClaimSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }

        
        internal UserClaimSelectByIdResponseModel UserClaimSelectByIdResponseModel(Domain.UserClaim input)
        {
            return new UserClaimSelectByIdResponseModel
            {
                ClaimID = input.ClaimID,
                RowCurrentVersion = input.CurrentRowVersion,
                UserID = input.UserID
            };
        }
    }
}
