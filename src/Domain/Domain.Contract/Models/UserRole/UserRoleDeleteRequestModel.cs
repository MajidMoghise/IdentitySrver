namespace Domain.Contract.Models.UserRole
{
    public class UserRoleDeleteRequestModel
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public byte[] CurrentRowVersion{ get; set; }
    }
}
