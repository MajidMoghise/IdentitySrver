namespace Domain.Contract.Models.Users
{
    public class UserTokenValidModelResponse
    {
        public int UserID { get; set; }
        public DateTime TokenCreate { get; set; }
        public DateTime TokenDateValid { get; set; }
        public Guid TokenGuid { get; set; }
        public bool TokenIsValid { get; set; }
        public string TokenStr { get; set; }
    }

}
