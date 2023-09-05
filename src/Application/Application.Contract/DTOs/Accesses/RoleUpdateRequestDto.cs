namespace Application.Contract.DTOs.Accesses
{
    public class RoleUpdateRequestDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
