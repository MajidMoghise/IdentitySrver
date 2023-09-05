using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsLogin { get; set; }
        public byte[] CurrentRowVersion { get; set; }
        public Token Token { get; set; }
    }

}
