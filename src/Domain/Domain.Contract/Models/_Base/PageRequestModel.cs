using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract.Models.Base
{
    public class PageRequestModel
    {
        public int NumberInPage { get; set; } = 5;
        public int PageIndex { get; set; } = 1;
    }
    public class PageResponseModel
    {
        public int TotalObjectCount { get; set; }
        public int TotalPageCount { get; set; }

    }
    public class PageResponseModel<T> : PageResponseModel
    {
        public int PageIndex { get; set; }
        public List<T> Datas { get; set; }
    }
}
