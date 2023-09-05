namespace Application.Contract.DTOs.Accesses
{
    public class RoleUpdateResponseDto
    { 
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }

    }

}
