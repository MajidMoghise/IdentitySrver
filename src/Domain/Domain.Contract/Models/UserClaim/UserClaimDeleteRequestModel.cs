namespace Domain.Contract.Models.UserClaim
{
    public class UserClaimDeleteRequestModel
    {
        public int ClaimID { get; set; }
        public int UserID { get; set; }
        public byte[] CurrentRowVersion{ get; set; }
    }
}
