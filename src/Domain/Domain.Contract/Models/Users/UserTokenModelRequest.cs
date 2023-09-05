namespace Domain.Contract.Models.Users
{
    public class UserTokenModelRequest
    {
        public int UserID { get; set; }
        public Guid TokenGuid { get; set; }
        public string TokenStr { get; set; }
    }

}
