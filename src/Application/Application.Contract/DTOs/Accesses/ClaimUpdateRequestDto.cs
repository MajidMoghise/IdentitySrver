namespace Application.Contract.DTOs.Accesses
{
    public class ClaimUpdateRequestDto
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
