namespace Application.Contract.DTOs.Accesses
{
    public class ClaimUpdateResponseDto
    { 
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }

    }

}
