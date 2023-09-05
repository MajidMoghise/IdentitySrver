namespace Application.Contract.DTOs.Site
{
    public class ActionUpdateRequestDto
    {
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public int ControllerID { get; set; }
    }

}
