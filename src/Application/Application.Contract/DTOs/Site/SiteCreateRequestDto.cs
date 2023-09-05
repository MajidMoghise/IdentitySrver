using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteCreateRequestDto
    {
        public string SiteName { get; set; }
        public List<SiteAreaCreateRequestDto> Areas{ get; set; }
    }

}
