using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaCreateResponseDto
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public List<SiteAreaControllerCreateResponseDto> Controllers{ get; set; }

    }

}
