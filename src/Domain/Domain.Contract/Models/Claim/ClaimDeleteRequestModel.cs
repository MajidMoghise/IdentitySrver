namespace Domain.Contract.Models.Claim
{
    public class ClaimDeleteRequestModel
    {
        public int ClaimID { get; set; }
        public byte[]CurrentRowVersion{ get; set; }
    }
}
