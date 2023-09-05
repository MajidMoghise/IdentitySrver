using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaControllerCreateRequestDto
    {
        public string ControllerName { get; set; }
        public List<SiteAreaControllerActionCreateRequestDto> Actions { get; set; }
    }

}
