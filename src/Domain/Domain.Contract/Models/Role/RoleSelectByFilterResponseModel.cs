namespace Domain.Contract.Models.Role
{
    public class RoleSelectByFilterResponseModel
    {
        public int RoleID { get; set; }
        public int? ParentRoleID { get; set; }
        public string RoleName { get; set; }
        public string ParentRoleName { get; set; }
    }
}
