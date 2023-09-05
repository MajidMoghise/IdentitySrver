namespace Domain.Contract.Models.UserClaim
{
    public class UserClaimSelectByIdResponseModel
    {
        public int UserID { get; set; }
        public int ClaimID { get; set; }
        public byte[] RowCurrentVersion { get; set; }

    }
}
