namespace Application.Contract.DTOs.Accesses
{
    public class RoleCreateRequestDto
    {
        public string RoleName { get; set; }
        public int? ParentRoleID{ get; set; }
    }

}
