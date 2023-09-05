namespace Domain.Contract.Models.Action
{
    public class ActionUpdateRequestModel
    {
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public int ControllerID { get; set; }
        public byte[] CurrentRowVersion { get; set; }


    }

}
