namespace Application.Contract.DTOs.Accesses
{
    public class ClaimCreateResponseDto
    {
        public int ClaimID { get; set; }
        public string ClaimName { get; set; }
        public int? ParentClaimID { get; set; }

    }

}
