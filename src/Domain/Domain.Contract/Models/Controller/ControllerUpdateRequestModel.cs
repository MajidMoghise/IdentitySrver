namespace Domain.Contract.Models.Controller
{
    public class ControllerUpdateRequestModel
    {
        public int ControllerID { get; set; }
        public string ControllerName { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public int AreaID { get; set; }
    }

}
