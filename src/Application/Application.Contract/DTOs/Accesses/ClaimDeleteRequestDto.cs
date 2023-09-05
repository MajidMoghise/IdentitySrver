namespace Application.Contract.DTOs.Accesses
{
    public class ClaimDeleteRequestDto
    {
        public int ClaimID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
