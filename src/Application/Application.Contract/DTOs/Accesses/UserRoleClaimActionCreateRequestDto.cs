using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.DTOs.Accesses
{
    public class UserRoleClaimActionCreateRequestDto
    {
        public int UserID { get; set; }
        public int? ClaimID { get; set; }
        public int? RoleID { get; set; }
        public int ActionID { get; set; }

    }

}
