using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.UserRoleClaimAction
{
    public class UserRoleClaimActionSelectRequestModel:PageRequestModel
    {
        public int UserID { get; set; }
        public int? ClaimID { get; set; }
        public int? RoleID { get; set; }
        public int ActionID { get; set; }

    }
}
