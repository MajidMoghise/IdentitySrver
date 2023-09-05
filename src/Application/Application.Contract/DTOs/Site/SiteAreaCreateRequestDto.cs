using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaCreateRequestDto
    {
        public string AreaName { get; set; }
        public List<SiteAreaControllerCreateRequestDto> Controllers { get; set; }
    }

}
