namespace Application.Contract.DTOs.Site
{
    public class AreaUpdateRequestDto
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
