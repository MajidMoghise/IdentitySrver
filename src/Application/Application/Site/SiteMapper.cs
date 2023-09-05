using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Site;
using Domain.Contract.Models.Action;
using Domain.Contract.Models.Area;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Controller;
using Domain.Contract.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site
{
    internal class SiteMapper
    {
        internal ActionCreateRequestModel ActionCreateRequestModel(SiteAreaControllerActionCreateRequestDto input, int controllerID)
        {
            return new ActionCreateRequestModel
            {
                ActionName = input.ActionName,
                ControllerID = controllerID
            };
        }

        internal AreaCreateRequestModel AreaCreateRequestModel(SiteAreaCreateRequestDto input, int siteID)
        {
            return new AreaCreateRequestModel
            {
                AreaName = input.AreaName,
                SiteID = siteID
            };
        }

        internal ControllerCreateRequestModel ControllerCreateRequestModel(SiteAreaControllerCreateRequestDto input, int areaID)
        {
            return new ControllerCreateRequestModel
            {
                ControllerName = input.ControllerName,
                AreaID = areaID
            };
        }

        internal static List<AreaCreateRequestModel> List_AreaCreateRequestModel(List<SiteAreaCreateRequestDto> input, int siteId)
        {
            return input.Select(s => new AreaCreateRequestModel
            {
                AreaName = s.AreaName,
                SiteID = siteId,
            }).ToList();
        }

        internal SiteCreateResponseDto SiteCreateResponseDto(SiteCreateResponseModel input, List<SiteAreaCreateResponseDto> inputList)
        {
            return new SiteCreateResponseDto
            {
                SiteID = input.SiteID,
                SiteName = input.SiteName,
                Areas = inputList
            };
        }

        internal SiteCreateRequestModel SiteCreateRequestModel(SiteCreateRequestDto input)
        {
            return new SiteCreateRequestModel
            {
                SiteName = input.SiteName
            };
        }

        internal SiteAreaCreateResponseDto SiteAreaCreateResponseDto(AreaCreateResponseModel input, List<SiteAreaControllerCreateResponseDto> inputList)
        {
            return new SiteAreaCreateResponseDto
            {
                AreaName = input.AreaName,
                AreaID = input.AreaID,
                Controllers = inputList
            };
        }

        internal SiteAreaControllerCreateResponseDto SiteAreaControllerCreateResponseDto(ControllerCreateResponseModel input, List<SiteAreaControllerActionCreateResponseDto> inputList)
        {
            return new SiteAreaControllerCreateResponseDto
            {
                ControllerID = input.ControllerID,
                ControllerName = input.ControllerName,
                Actions = inputList,
            };
        }

        internal SiteAreaControllerActionCreateResponseDto SiteAreaControllerActionCreateResponseDto(ActionCreateResponseModel input)
        {
            return new SiteAreaControllerActionCreateResponseDto
            {
                ActionID = input.ActionID,
                ActionName = input.ActionName
            };
        }

        internal ActionDeleteRequestModel ActionDeleteRequestModel(ActionDeleteRequestDto input)
        {
            return new ActionDeleteRequestModel
            {
                ActionID = input.ActionID,
                CurrentRowVersion = input.CurrentRowVersion
            };
        }

        internal ActionDeleteResponseDto ActionDeleteResponseDto(ActionDeleteResponseModel input)
        {
            return new ActionDeleteResponseDto
            {
                ActionID = input.ActionID
            };
        }

        internal AreaDeleteRequestModel AreaDeleteRequestModel(AreaDeleteRequestDto input)
        {
            return new AreaDeleteRequestModel
            {
                AreaID = input.AreaID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal AreaDeleteResponseDto AreaDeleteResponseDto(AreaDeleteResponseModel input)
        {
            return new AreaDeleteResponseDto
            {
                AreaID = input.AreaID
            };
        }

        internal ControllerDeleteRequestModel ControllerDeleteRequestModel(ControllerDeleteRequestDto input)
        {
            return new ControllerDeleteRequestModel
            {
                ControllerID = input.ControllerID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal ControllerDeleteResponseDto ControllerDeleteResponseDto(ControllerDeleteResponseModel input)
        {
            return new ControllerDeleteResponseDto
            {
                ControllerID = input.ControllerID
            };
        }

        internal SiteDeleteRequestModel SiteDeleteRequestModel(SiteDeleteRequestDto input)
        {
            return new SiteDeleteRequestModel
            {
                SiteID = input.SiteID,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal SiteDeleteResponseDto SiteDeleteResponseDto(SiteDeleteResponseModel input)
        {
            return new SiteDeleteResponseDto
            {
                SiteID = input.SiteID
            };
        }

        internal ActionSelectByIdRequestModel ActionSelectByIdRequestModel(ActionSelectByIdRequstDto input)
        {
            return new ActionSelectByIdRequestModel
            {
                ActionID = input.ActionID
            };
        }

        internal ActionSelectByIdResponseDto ActionSelectByIdResponseDto(ActionSelectByIdResponseModel input)
        {
            return new ActionSelectByIdResponseDto
            {
                ActionID = input.ActionID,
                ActionName = input.ActionName,
                AreaID = input.ActionID,
                CurrentRowVersion = input.CurrentRowVersion,
                AreaName = input.AreaName,
                ControllerID = input.ControllerID,
                ControllerName = input.ControllerName,
                SiteID = input.SiteID,
                SiteName = input.SiteName,
            };
        }

        internal AreaSelectByIdRequestModel AreaSelectByIdRequestModel(AreaSelectByIdResponseDto input)
        {
            return new AreaSelectByIdRequestModel
            {
                AreaID = input.AreaID,
            };
        }

        internal AreaSelectByIdResponseDto AreaSelectByIdResponseDto(AreaSelectByIdResponseModel input)
        {
            return new AreaSelectByIdResponseDto
            {
                AreaID = input.AreaID,
                SiteName = input.SiteName,
                SiteID = input.SiteID,
                AreaName = input.AreaName,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal ControllerSelectByIdRequestModel ControllerSelectByIdRequestModel(ControllerSelectByIdRequstDto input)
        {
            return new ControllerSelectByIdRequestModel
            {
                ControllerID = input.ControllerID
            };
        }

        internal ControllerSelectByIdResponseDto ControllerSelectByIdResponseDto(ControllerSelectByIdResponseModel input)
        {
            return new ControllerSelectByIdResponseDto
            {
                AreaID = input.AreaID,
                ControllerID = input.ControllerID,
                CurrentRowVersion = input.CurrentRowVersion,
                AreaName = input.AreaName,
                SiteID = input.SiteID,
                ControllerName = input.ControllerName,
                SiteName = input.SiteName
            };
        }

        internal SiteSelectByIdRequestModel SiteSelectByIdRequestModel(SiteSelectByIdRequestDto input)
        {
            return new SiteSelectByIdRequestModel
            {
                SiteID = input.SiteID
            };
        }

        internal SiteSelectByIdResponseDto SiteSelectByIdResponseDto(SiteSelectByIdResponseModel input)
        {
            return new SiteSelectByIdResponseDto
            {
                SiteID = input.SiteID,
                SiteName = input.SiteName,
                CurrentRowVersion = input.CurrentRowVersion,
                SiteDomain = input.SiteDomain,
                SitePath = input.SitePath,
                SitePort = input.SitePort,
            };
        }

        internal ActionUpdateRequestModel ActionUpdateRequestModel(ActionUpdateRequestDto input)
        {
            return new ActionUpdateRequestModel
            {
                ActionID = input.ActionID,
                CurrentRowVersion = input.CurrentRowVersion,
                ActionName = input.ActionName,
                ControllerID = input.ControllerID
            };
        }

        internal ActionUpdateResponseDto ActionUpdateResponseDto(ActionUpdateResponseModel input)
        {
            return new ActionUpdateResponseDto
            {
                ActionName = input.ActionName,
                ActionID = input.ActionID,

            };
        }

        internal AreaUpdateRequestModel AreaUpdateRequestModel(AreaUpdateRequestDto input)
        {
            return new AreaUpdateRequestModel
            {
                AreaID = input.AreaID,
                AreaName = input.AreaName,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal AreaUpdateResponseDto AreaUpdateResponseDto(AreaUpdateResponseModel input)
        {
            return new AreaUpdateResponseDto
            {
                AreaName = input.AreaName,
                AreaID = input.AreaID,
            };
        }
        internal ControllerUpdateRequestModel ControllerUpdateRequestModel(ControllerUpdateRequestDto input)
        {
            return new ControllerUpdateRequestModel
            {
                ControllerID = input.ControllerID,
                ControllerName = input.ControllerName,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal ControllerUpdateResponseDto ControllerUpdateResponseDto(ControllerUpdateResponseModel input)
        {
            return new ControllerUpdateResponseDto
            {
                ControllerName = input.ControllerName,
                ControllerID = input.ControllerID,
            };
        }
        internal SiteUpdateRequestModel SiteUpdateRequestModel(SiteUpdateRequestDto input)
        {
            return new SiteUpdateRequestModel
            {
                SiteID = input.SiteID,
                SiteName = input.SiteName,
                CurrentRowVersion = input.CurrentRowVersion,
            };
        }

        internal SiteUpdateResponseDto SiteUpdateResponseDto(SiteUpdateResponseModel input)
        {
            return new SiteUpdateResponseDto
            {
                SiteName = input.SiteName,
                SiteID = input.SiteID,
                SiteDomain = input.SiteDomain,
                SitePath = input.SitePath,
                SitePort = input.SitePort
            };
        }

        internal SiteSelectByFilterRequestModel SiteSelectByFilterRequestModel(SiteSelectByFilterRequestDto input)
        {
            return new SiteSelectByFilterRequestModel
            {
                SiteName = input.SiteName,

            };
        }

        internal PageResponseDto<SiteSelectByFilterResponseDto> PageResponseDto_SiteSelectByFilterResponseDto(PageResponseModel<SiteSelectByFilterResponseModel> input)
        {
            return new PageResponseDto<SiteSelectByFilterResponseDto>
            {
                Datas = input.Datas.Select(s => new SiteSelectByFilterResponseDto
                {
                    SiteID = s.SiteID,
                    SiteName = s.SiteName,

                }).ToList(),
                TotalPageCount = input.TotalPageCount,
                TotalObjectCount = input.TotalPageCount,
                PageIndex = input.PageIndex,
            }
            ;
        }

        
    }
}
