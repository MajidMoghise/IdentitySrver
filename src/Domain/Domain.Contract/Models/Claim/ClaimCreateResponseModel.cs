namespace Domain.Contract.Models.Claim
{
    public class ClaimCreateResponseModel
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }

    }
}
