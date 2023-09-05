using Domain.Contract.Models.Base;

namespace Domain.Contract.Models.Site
{
    public class SiteSelectByFilterRequestModel: PageRequestModel
    {
        public string SiteName { get; set; }
    }

}
