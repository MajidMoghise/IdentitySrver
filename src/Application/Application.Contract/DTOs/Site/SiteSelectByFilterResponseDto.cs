using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteSelectByFilterResponseDto
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteDomain { get; set; }
        public string SitePath { get; set; }
        public int SitePort { get; set; }
        public List<SiteAreaSelectByFilterResponseDto> Areas{ get; set; }
    }

}
