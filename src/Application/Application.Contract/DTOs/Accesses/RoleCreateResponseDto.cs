namespace Application.Contract.DTOs.Accesses
{
    public class RoleCreateResponseDto
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }

    }

}
