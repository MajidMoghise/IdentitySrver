namespace Domain.Contract.Models.Claim
{
    public class ClaimUpdateRequestModel
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }
}
