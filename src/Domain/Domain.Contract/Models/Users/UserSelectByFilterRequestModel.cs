using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.Users
{
    public class UserSelectByFilterRequestModel: PageRequestModel
    {
        public string UserName { get; set; }
    }

}
