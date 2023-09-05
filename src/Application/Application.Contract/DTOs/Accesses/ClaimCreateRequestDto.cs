namespace Application.Contract.DTOs.Accesses
{
    public class ClaimCreateRequestDto
    {
        public string ClaimName { get; set; }
        public int? ParentClaimID{ get; set; }
    }

}
