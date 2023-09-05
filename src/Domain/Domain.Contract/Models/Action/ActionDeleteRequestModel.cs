namespace Domain.Contract.Models.Action
{
    
    public class ActionDeleteRequestModel
    {
        public int ActionID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
