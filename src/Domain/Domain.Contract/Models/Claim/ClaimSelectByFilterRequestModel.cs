using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.Claim
{
    public class ClaimSelectByFilterRequestModel:PageRequestModel
    {
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
    }
}
