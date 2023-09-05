namespace Domain.Contract.Models.UserClaim
{
    public class UserClaimSelectByFilterResponseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public string ParentClaimName { get; set; }
        public int? ParentClaimID{ get; set; }
    }
}
