using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Dtos.Base
{
    public class PageRequestDto
    {
        public int NumberInPage { get; set; } = 5;
        public int PageIndex { get; set; } = 1;
    }
    public class PageResponseDto
    {
        public int TotalObjectCount { get; set; }
        public int TotalPageCount { get; set; }

    }
    public class PageResponseDto<T> : PageResponseDto
    {
        public int PageIndex { get; set; }
        public List<T> Datas { get; set; }
    }
}
