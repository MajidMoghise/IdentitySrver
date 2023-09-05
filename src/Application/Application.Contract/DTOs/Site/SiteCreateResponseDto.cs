using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteCreateResponseDto
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public List<SiteAreaCreateResponseDto> Areas { get; set; }

    }

}
