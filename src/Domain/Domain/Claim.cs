namespace Domain
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Claim ParentClaim { get; set; }
    }

}
