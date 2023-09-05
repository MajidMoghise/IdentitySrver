namespace Domain.Contract.Models.Role
{
    public class RoleUpdateResponseModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }

    }
}
