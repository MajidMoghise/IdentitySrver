using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Applications
{
    public interface ISiteService
    {
        public Task<PageResponseDto<SiteSelectByFilterResponseDto>> SelectSiteByFilter(SiteSelectByFilterRequestDto dto);
        public Task<SiteSelectByIdResponseDto> SelectSiteByID(SiteSelectByIdRequestDto dto);
        public Task<AreaSelectByIdResponseDto> SelectAreaByID(AreaSelectByIdResponseDto dto);
        public Task<ControllerSelectByIdResponseDto> SelectControllerByID(ControllerSelectByIdRequstDto dto);
        public Task<ActionSelectByIdResponseDto> SelectActionByID(ActionSelectByIdRequstDto dto);
        public Task<SiteCreateResponseDto> CreateSite(SiteCreateRequestDto dto);
        public Task<SiteDeleteResponseDto> DeleteSite(SiteDeleteRequestDto dto);
        public Task<SiteUpdateResponseDto> UpdateSite(SiteUpdateRequestDto dto);

        public Task<AreaDeleteResponseDto> DeleteArea(AreaDeleteRequestDto dto);
        public Task<AreaUpdateResponseDto> UpdateArea(AreaUpdateRequestDto dto);
        
        public Task<ControllerDeleteResponseDto> DeleteController(ControllerDeleteRequestDto dto);
        public Task<ControllerUpdateResponseDto> UpdateController(ControllerUpdateRequestDto dto);
        
        public Task<ActionDeleteResponseDto> DeleteAction(ActionDeleteRequestDto dto);
        public Task<ActionUpdateResponseDto> UpdateAction(ActionUpdateRequestDto dto);      
    }
}
