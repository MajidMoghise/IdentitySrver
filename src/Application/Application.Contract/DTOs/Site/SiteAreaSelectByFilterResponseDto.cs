using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaSelectByFilterResponseDto
    {
        public string AreaName { get; set; }
        public List<SiteAreaControllerSelectByFilterResponseDto> Controllers{ get; set; }
    }

}
