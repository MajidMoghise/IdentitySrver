namespace Domain.Contract.Models.UserRole
{
    public class UserRoleSelectByFilterResponseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string ParentRoleName { get; set; }
        public int? ParentRoleID{ get; set; }
    }
}
