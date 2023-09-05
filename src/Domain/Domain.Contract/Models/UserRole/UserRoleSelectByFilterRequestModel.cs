using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.UserRole
{
    public class UserRoleSelectByFilterRequestModel : PageRequestModel
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public int? UserID { get; set; }
        public int? RoleID{ get; set; }
    }
}
