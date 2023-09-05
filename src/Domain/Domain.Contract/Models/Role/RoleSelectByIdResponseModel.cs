namespace Domain.Contract.Models.Role
{
    public class RoleSelectByIdResponseModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }
}
