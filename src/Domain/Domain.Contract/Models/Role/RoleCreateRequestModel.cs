namespace Domain.Contract.Models.Role
{
    public class RoleCreateRequestModel
    {
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
    }
}
