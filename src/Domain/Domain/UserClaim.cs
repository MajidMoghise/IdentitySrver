namespace Domain
{
    public class UserClaim
    {
        public int ClaimID { get; set; }
        public int UserID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Claim Claim { get; set; }
        public User User { get; set; }
    }

}
