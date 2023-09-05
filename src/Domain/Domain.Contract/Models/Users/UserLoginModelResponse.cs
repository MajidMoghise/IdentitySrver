namespace Domain.Contract.Models.Users
{
    public class UserLoginModelResponse
    {
        public int UserID { get; set; }
        public bool TokenIsValid { get; set; }
        public DateTime TokenCreate { get; set; }
        public DateTime TokenDateValid { get; set; }
        public bool IsLogin { get; set; }
        public bool IsActive { get; set; }
    }

}
