namespace Domain
{
    public class Action
    {
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public int ControllerID { get; set; }
        public byte[] CurrentRowVersion{ get; set; }

        public Controller Controller { get; set; }
    }


}
