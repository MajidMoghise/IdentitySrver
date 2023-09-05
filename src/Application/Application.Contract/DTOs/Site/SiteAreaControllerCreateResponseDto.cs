using System.Collections.Generic;

namespace Application.Contract.DTOs.Site
{
    public class SiteAreaControllerCreateResponseDto
    {
        public int ControllerID { get; set; }
        public string ControllerName { get; set; }
        public List<SiteAreaControllerActionCreateResponseDto> Actions { get; set; }
    }

}
