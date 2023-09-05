using System.Collections.Generic;

namespace Domain.Contract.Models.Site
{
    public class SiteCreateResponseModel
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteDomain { get; set; }
        public string SitePath { get; set; }
        public int SitePort { get; set; }

    }

}
