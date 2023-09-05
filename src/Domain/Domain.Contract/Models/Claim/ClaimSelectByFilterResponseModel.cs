namespace Domain.Contract.Models.Claim
{
    public class ClaimSelectByFilterResponseModel
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
        public string ParentClaimName { get; set; }
    }
}
