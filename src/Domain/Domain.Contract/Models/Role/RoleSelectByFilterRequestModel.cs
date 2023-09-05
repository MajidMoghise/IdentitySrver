using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.Role
{
    public class RoleSelectByFilterRequestModel:PageRequestModel
    {
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
    }
}
