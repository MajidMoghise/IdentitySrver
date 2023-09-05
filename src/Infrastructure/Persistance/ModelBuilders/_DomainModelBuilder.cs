using Persistance.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.ModelBuilders
{
    public static class _DomainModelBuilder
    {
        public static void DomainBuilder(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuider)
        {
            modelBuider.ActionBuilder();
            modelBuider.AreaBuilder();
            modelBuider.ClaimModelBuilder();
            modelBuider.ControllerBuilder();
            modelBuider.RoleBuilder();
            modelBuider.SiteBuilder();
            modelBuider.TokenBuilder();
            modelBuider.UserBuilder();
            modelBuider.UserRoleClaimActionBuilder();
       
        }
    }
}
