namespace Application.Contract.DTOs.Accesses
{
    public class RoleDeleteRequestDto
    {
        public int RoleID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
