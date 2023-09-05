namespace Domain.Contract.Models.UserRole
{
    public class UserRoleSelectByIdResponseModel
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public byte[] RowCurrentVersion { get; set; }

    }
}
