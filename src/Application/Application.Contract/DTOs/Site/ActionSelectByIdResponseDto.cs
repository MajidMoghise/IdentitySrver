namespace Application.Contract.DTOs.Site
{
    public class ActionSelectByIdResponseDto
    {
        public int ActionID { get; set; }
        public int ControllerID { get; set; }
        public int AreaID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
