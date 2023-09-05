namespace Application.Contract.DTOs.Site
{
    public class SiteDeleteRequestDto
    {
        public int SiteID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
    }

}
