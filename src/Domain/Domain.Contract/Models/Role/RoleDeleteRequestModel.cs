namespace Domain.Contract.Models.Role
{
    public class RoleDeleteRequestModel
    {
        public int RoleID { get; set; }
        public byte[] CurrentRowVersion{ get; set; }
    }
}
