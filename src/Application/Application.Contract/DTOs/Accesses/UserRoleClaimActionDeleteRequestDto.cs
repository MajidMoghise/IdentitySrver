namespace Application.Contract.DTOs.Accesses
{
    public class UserRoleClaimActionDeleteRequestDto
    {
        public int UserID { get; set; }
        public int? ClaimID { get; set; }
        public int? RoleID { get; set; }
        public int ActionID { get; set; }

        public byte[] CurrentRowVersion { get; set; }


    }

}
