namespace Domain.Contract.Models.Users
{
    public class UserResetPasswordRequestModel
    {
        public int UserID { get; set; }
        public string Password { get; set; }
    }
}
