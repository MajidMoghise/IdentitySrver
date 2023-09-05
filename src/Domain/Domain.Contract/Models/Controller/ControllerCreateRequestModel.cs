using System.Collections.Generic;
using Domain.Contract.Models.Action;

namespace Domain.Contract.Models.Controller
{
    public class ControllerCreateRequestModel
    {
        public string ControllerName { get; set; }
        public int AreaID { get; set; }
    }

}
