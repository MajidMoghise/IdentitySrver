using System;

namespace Application.Contract.DTOs.User
{
    public class UserTokenVM
    {
        public int TokenID { get; set; }
        public int UserID { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Active { get; set; }
        public int SystemUserID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string SiteName { get; set; }
        public string AriaName { get; set; }
    }

}
