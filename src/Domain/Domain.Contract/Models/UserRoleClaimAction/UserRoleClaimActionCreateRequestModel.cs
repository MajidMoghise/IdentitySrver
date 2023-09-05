namespace Domain.Contract.Models.UserRoleClaimAction
{
    public class UserRoleClaimActionCreateRequestModel
    {
        public int UserID { get; set; }
        public int? ClaimID { get; set; }
        public int? RoleID { get; set; }
        public int ActionID { get; set; }

    }
}
