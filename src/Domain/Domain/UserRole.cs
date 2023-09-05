namespace Domain
{
    public class UserRole
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }

}
