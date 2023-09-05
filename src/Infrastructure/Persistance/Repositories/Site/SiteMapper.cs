using Domain.Contract.Models.Base;
using Domain.Contract.Models.Site;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Site
{
    internal class SiteMapper
    {
        internal Domain.Site Site(SiteCreateRequestModel input)
        {
            return new Domain.Site
            {
                SiteName = input.SiteName,
            };
        }

        internal Domain.Site Site(SiteUpdateRequestModel input)
        {
            return new Domain.Site
            {
                SiteName = input.SiteName,
                SiteID = input.SiteID,
                CurrentRowVersion = input.CurrentRowVersion,
                SiteDomain=input.SiteDomain,
                SitePath=input.SitePath,
                SitePort=input.SitePort
            };
        }

        internal Domain.Site Site(SiteDeleteRequestModel input)
        {
            return new Domain.Site
            {
                SiteID = input.SiteID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal SiteCreateResponseModel SiteCreateResponseModel(EntityEntry<Domain.Site> input)
        {
            return new SiteCreateResponseModel
            {
                SiteName = (string)input.CurrentValues[nameof(Domain.Site.SiteName)],
                SiteID = (int)input.CurrentValues[nameof(Domain.Site.SiteID)],
                 SitePort= (int)input.CurrentValues[nameof(Domain.Site.SitePort)],
                 SitePath= (string)input.CurrentValues[nameof(Domain.Site.SitePath)],
                 SiteDomain= (string)input.CurrentValues[nameof(Domain.Site.SiteDomain)],
                 
            };
        }

        internal SiteDeleteResponseModel SiteDeleteResponseModel(EntityEntry<Domain.Site> input)
        {
            return new SiteDeleteResponseModel
            {
                SiteID = (int)input.CurrentValues[nameof(Domain.Site.SiteID)],
            };
        }

        internal Expression<Func<Domain.Action, SiteSelectByFilterResponseModel>> SiteSelectByFilterResponseModel = (input) =>

           new SiteSelectByFilterResponseModel
           {
               SiteID = input.Controller.Area.Site.SiteID,
               SiteName = input.Controller.Area.Site.SiteName,
               ActionID=input.ActionID,
               ActionName=input.ActionName,
               AreaID = input.Controller.Area.AreaID,
               AreaName=input.Controller.Area.AreaName,
               ControllerID=input.ControllerID,
               ControllerName=input.Controller.ControllerName
               
           };
        internal Expression<Func<Domain.Site, SiteSelectByIdResponseModel>> SiteSelectByIdResponseModel = (input) =>

           new SiteSelectByIdResponseModel
           {
               SiteID = input.SiteID,
               SiteName = input.SiteName,
               CurrentRowVersion=input.CurrentRowVersion,
               SiteDomain=input.SiteDomain,
               SitePath = input.SitePath,
               SitePort=input.SitePort,
               
           };
        internal SiteUpdateResponseModel SiteUpdateResponseModel(EntityEntry<Domain.Site> input)
        {
            return new SiteUpdateResponseModel
            {
                SiteName = (string)input.CurrentValues[nameof(Domain.Site.SiteName)],
                SiteID = (int)input.CurrentValues[nameof(Domain.Site.SiteID)],
                SitePort = (int)input.CurrentValues[nameof(Domain.Site.SitePort)],
                SitePath = (string)input.CurrentValues[nameof(Domain.Site.SitePath)],
                SiteDomain = (string)input.CurrentValues[nameof(Domain.Site.SiteDomain)],
            };
        }

        internal PageResponseModel<SiteSelectByFilterResponseModel> PageResponseModel_SiteSelectByFilterResponseModel(List<SiteSelectByFilterResponseModel> input, int pageIndex, int totalCount, int pageCount)
        {
            return new PageResponseModel<SiteSelectByFilterResponseModel>
            {
                Datas = input,
                PageIndex = pageIndex,
                TotalObjectCount = totalCount,
                TotalPageCount = pageCount
            };
        }
    }
}
