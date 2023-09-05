using Domain.Contract.Models.Controller;
using Domain.Contract.Models.Site;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Controller
{
    internal class ControllerMapper
    {
        internal Domain.Controller Controller(ControllerCreateRequestModel input)
        {
            return new Domain.Controller
            {
                ControllerName = input.ControllerName,
            };
        }

        internal Domain.Controller Controller(ControllerUpdateRequestModel input)
        {
            return new Domain.Controller
            {
                ControllerName = input.ControllerName,
                ControllerID = input.ControllerID,
                AreaID = input.ControllerID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal Domain.Controller Controller(ControllerDeleteRequestModel input)
        {
            return new Domain.Controller
            {
                ControllerID = input.ControllerID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal ControllerCreateResponseModel ControllerCreateResponseModel(EntityEntry<Domain.Controller> input)
        {
            return new ControllerCreateResponseModel
            {
                ControllerName = (string)input.CurrentValues[nameof(Domain.Controller.ControllerName)],
                ControllerID = (int)input.CurrentValues[nameof(Domain.Controller.ControllerID)],
                AreaID = (int)input.CurrentValues[nameof(Domain.Controller.AreaID)]
            };
        }

        internal ControllerDeleteResponseModel ControllerDeleteResponseModel(EntityEntry<Domain.Controller> input)
        {
            return new ControllerDeleteResponseModel
            {
                ControllerID = (int)input.CurrentValues[nameof(Domain.Controller.ControllerID)],
            };
        }

        internal Expression<Func<Domain.Controller, ControllerSelectByIdResponseModel>> ControllerSelectByIdResponseModel = (input) =>

           new ControllerSelectByIdResponseModel
           {
               ControllerID = input.ControllerID,
               ControllerName = input.ControllerName,
               AreaID = input.Area.AreaID,
               AreaName = input.Area.AreaName,
               CurrentRowVersion=input.CurrentRowVersion,
               SiteID=input.Area.SiteID,
               SiteName=input.Area.Site.SiteName,
           };
        internal ControllerUpdateResponseModel ControllerUpdateResponseModel(EntityEntry<Domain.Controller> input)
        {
            return new ControllerUpdateResponseModel
            {
                ControllerName =(string) input.CurrentValues[nameof(Domain.Controller.ControllerName)],
                ControllerID =(int) input.CurrentValues[nameof(Domain.Controller.ControllerID)],
                AreaID = (int)input.CurrentValues[nameof(Domain.Controller.AreaID)]
            };
        }

    }
}
