namespace Application.Contract.DTOs.Site
{
    
    public class ActionDeleteRequestDto
    {
        public int ActionID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
