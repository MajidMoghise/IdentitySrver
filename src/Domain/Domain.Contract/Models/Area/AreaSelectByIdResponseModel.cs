namespace Domain.Contract.Models.Area
{
    public class AreaSelectByIdResponseModel
    {
        public int AreaID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string AreaName { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
