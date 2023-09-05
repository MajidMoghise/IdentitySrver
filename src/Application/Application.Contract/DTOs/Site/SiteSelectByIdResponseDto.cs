namespace Application.Contract.DTOs.Site
{
    public class SiteSelectByIdResponseDto
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteDomain { get; set; }
        public string SitePath { get; set; }
        public int SitePort { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
