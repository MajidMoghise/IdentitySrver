namespace Domain.Contract.Models.Site
{
    public class SiteSelectByIdResponseModel
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteDomain { get; set; }
        public string SitePath { get; set; }
        public int SitePort { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
