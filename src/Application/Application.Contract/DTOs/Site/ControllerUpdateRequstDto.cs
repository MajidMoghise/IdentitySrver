namespace Application.Contract.DTOs.Site
{
    public class ControllerUpdateRequestDto
    {
        public int ControllerID { get; set; }
        public string ControllerName { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
