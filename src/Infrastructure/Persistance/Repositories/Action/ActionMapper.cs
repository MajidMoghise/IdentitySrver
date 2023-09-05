using Domain.Contract.Models.Action;
using Domain.Contract.Models.Site;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Action
{
    internal class ActionMapper
    {
        internal Domain.Action Action(ActionCreateRequestModel input)
        {
            return new Domain.Action
            {
                ActionName = input.ActionName,
            };
        }

        internal Domain.Action Action(ActionUpdateRequestModel input)
        {
            return new Domain.Action
            {
                ActionName = input.ActionName,
                ActionID = input.ActionID,
                ControllerID = input.ControllerID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal Domain.Action Action(ActionDeleteRequestModel input)
        {
            return new Domain.Action
            {
                ActionID = input.ActionID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal ActionCreateResponseModel ActionCreateResponseModel(EntityEntry<Domain.Action> input)
        {
            return new ActionCreateResponseModel
            {
                ActionName = (string)input.CurrentValues[nameof(Domain.Action.ActionName)],
                ActionID = (int)input.CurrentValues[nameof(Domain.Action.ActionID)],
                ControllerID = (int)input.CurrentValues[nameof(Domain.Action.ControllerID)]
            };
        }

        internal ActionDeleteResponseModel ActionDeleteResponseModel(EntityEntry<Domain.Action> input)
        {
            return new ActionDeleteResponseModel
            {
                ActionID = (int)input.CurrentValues[nameof(Domain.Action.ActionID)],
            };
        }

        internal Expression<Func<Domain.Action, ActionSelectByIdResponseModel>> ActionSelectByIdResponseModel = (input) =>

           new ActionSelectByIdResponseModel
           {
               ActionID = input.ActionID,
               ActionName = input.ActionName,
               AreaID = input.Controller.AreaID,
               AreaName = input.Controller.Area.AreaName,
               ControllerID=input.ControllerID,
               ControllerName=input.Controller.ControllerName,
               CurrentRowVersion=input.CurrentRowVersion,
               SiteID=input.Controller.Area.SiteID,
               SiteName=input.Controller.Area.Site.SiteName,
           };
        internal ActionUpdateResponseModel ActionUpdateResponseModel(EntityEntry<Domain.Action> input)
        {
            return new ActionUpdateResponseModel
            {
                ActionName =(string) input.CurrentValues[nameof(Domain.Action.ActionName)],
                ActionID =(int) input.CurrentValues[nameof(Domain.Action.ActionID)],
                ControllerID = (int)input.CurrentValues[nameof(Domain.Action.ControllerID)]
            };
        }

    }
}
