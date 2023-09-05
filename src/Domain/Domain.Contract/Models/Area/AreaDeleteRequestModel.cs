namespace Domain.Contract.Models.Area
{
    public class AreaDeleteRequestModel
    {
        public int AreaID { get; set; }
        public byte[] CurrentRowVersion { get; set; }

    }

}
