namespace Domain
{
    public class Controller
    {
        public int ControllerID { get; set; }
        public string ControllerName { get; set; }
        public int AreaID { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Area Area { get; set; }

    }

}
