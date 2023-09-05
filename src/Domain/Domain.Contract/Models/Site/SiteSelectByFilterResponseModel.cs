using System.Collections.Generic;

namespace Domain.Contract.Models.Site
{
    public class SiteSelectByFilterResponseModel
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public int ControllerID { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
    }

}
