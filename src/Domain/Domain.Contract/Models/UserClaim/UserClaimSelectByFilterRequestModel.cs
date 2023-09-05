using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.UserClaim
{
    public class UserClaimSelectByFilterRequestModel : PageRequestModel
    {
        public string ClaimName { get; set; }
        public string UserName { get; set; }
        public int? UserID { get; set; }
        public int? ClaimID{ get; set; }
    }
}
