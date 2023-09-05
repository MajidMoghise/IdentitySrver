namespace Domain.Contract.Models.Site
{
    public class SiteDeleteRequestModel
    {
        public int SiteID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
