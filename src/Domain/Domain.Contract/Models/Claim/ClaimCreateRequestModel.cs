namespace Domain.Contract.Models.Claim
{
    public class ClaimCreateRequestModel
    {
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
    }
}
