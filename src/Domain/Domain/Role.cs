namespace Domain
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Role ParentRole { get; set; }
    }

}
