using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaControllerSelectByFilterResponseDto
    {
        public string ControllerName { get; set; }
        public List<SiteAreaControllerActionSelectByFilterResponseDto> Actions{ get; set; }

    }

}
