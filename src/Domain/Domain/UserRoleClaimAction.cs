namespace Domain
{
    public class UserRoleClaimAction
    {
        public int UserID { get; set; }
        public int? ClaimID { get; set; }
        public int? RoleID { get; set; }
        public int ActionID { get; set; }
        
        public Action Action { get; set; }
        public User User { get; set; }
        public Claim Claim { get; set; }
        public Role Role{ get; set; }
        public byte[] CurrentRowVersion { get; set; }


    }

}
