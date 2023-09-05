namespace Domain.Contract.Models.Users
{
    public class UserSelectByFilterResponseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsLogin { get; set; }

    }
}
