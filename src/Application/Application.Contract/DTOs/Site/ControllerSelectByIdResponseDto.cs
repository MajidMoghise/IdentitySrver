﻿namespace Application.Contract.DTOs.Site
{
    public class ControllerSelectByIdResponseDto
    {
        public int ControllerID { get; set; }
        public int AreaID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
