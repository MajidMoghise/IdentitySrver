namespace Domain.Contract.Models.Area
{
    public class AreaUpdateRequestModel
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public int SiteID { get; set; }
    }

}
