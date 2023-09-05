namespace Domain
{
    public class Area
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int SiteID { get; set; }

        public byte[] CurrentRowVersion { get; set; }
        public Site Site { get; set; }
    }

}
