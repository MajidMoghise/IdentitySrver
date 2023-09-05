namespace Domain.Contract.Models.Users
{
    public class UserDisableRequestModel
    {
        public int UserID { get; set; }
        public bool IsActive { get; set; }
    }
}
