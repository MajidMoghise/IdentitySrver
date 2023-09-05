using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.DTOs.Token
{
    public class TokenJwtCreateDto
    {
        public Guid TokenGuid { get; set; }
        public int UserID { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
    }
}
