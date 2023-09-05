using Domain.Contract.Models.Area;
using Domain.Contract.Models.Site;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Area
{
    internal class AreaMapper
    {
        internal Domain.Area Area(AreaCreateRequestModel input)
        {
            return new Domain.Area
            {
                AreaName = input.AreaName,
            };
        }

        internal Domain.Area Area(AreaUpdateRequestModel input)
        {
            return new Domain.Area
            {
                AreaName = input.AreaName,
                AreaID = input.AreaID,
                SiteID = input.SiteID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal Domain.Area Area(AreaDeleteRequestModel input)
        {
            return new Domain.Area
            {
                AreaID = input.AreaID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal AreaCreateResponseModel AreaCreateResponseModel(EntityEntry<Domain.Area> input)
        {
            return new AreaCreateResponseModel
            {
                AreaName = (string)input.CurrentValues[nameof(Domain.Area.AreaName)],
                AreaID = (int)input.CurrentValues[nameof(Domain.Area.AreaID)],
                SiteID = (int)input.CurrentValues[nameof(Domain.Area.SiteID)]
            };
        }

        internal AreaDeleteResponseModel AreaDeleteResponseModel(EntityEntry<Domain.Area> input)
        {
            return new AreaDeleteResponseModel
            {
                AreaID = (int)input.CurrentValues[nameof(Domain.Area.AreaID)],
            };
        }

        internal Expression<Func<Domain.Area, AreaSelectByIdResponseModel>> AreaSelectByIdResponseModel = (input) =>

           new AreaSelectByIdResponseModel
           {
               AreaID = input.AreaID,
               AreaName = input.AreaName,
               CurrentRowVersion=input.CurrentRowVersion,
               SiteID=input.SiteID,
               SiteName=input.Site.SiteName,
           };
        internal AreaUpdateResponseModel AreaUpdateResponseModel(EntityEntry<Domain.Area> input)
        {
            return new AreaUpdateResponseModel
            {
                AreaName =(string) input.CurrentValues[nameof(Domain.Area.AreaName)],
                AreaID =(int) input.CurrentValues[nameof(Domain.Area.AreaID)],
                SiteID = (int)input.CurrentValues[nameof(Domain.Area.SiteID)]
            };
        }

    }
}
