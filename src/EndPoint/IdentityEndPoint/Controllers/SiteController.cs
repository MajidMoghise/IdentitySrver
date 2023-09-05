using Application.Contract.Applications;
using Application.Contract.Dtos.Base;
using Application.Contract.DTOs.Site;
using Domain.Contract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEndPoint.Controllers
{
    [ApiController]
    [Route("api/Site")]
    public class SiteController : ControllerBase
    {
        readonly ISiteService _site;
        public SiteController(ISiteService site)
        {
            _site = site;
        }
        [Route("api/Site/getall")]

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(SiteSelectByFilterRequestDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public Task<IActionResult> SelectSiteByFilter(SiteSelectByFilterRequestDto dto)
        {
            var resultFromService = _site.SelectSiteByFilter(dto).Result;
            IActionResult result;
            if (resultFromService.Datas.Count > 0)
            {
                result = Ok(resultFromService);
            }
            else
            {
                result = NotFound();
            }
            return Task.FromResult(result);
        }
        [Route("api/Site/get1")]
        //a.hassanabadi
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(SiteSelectByIdRequestDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public Task<IActionResult> SelectSiteByID(SiteSelectByIdRequestDto dto)
        {
            var resultService = _site.SelectSiteByID(dto).Result;
            IActionResult result;
            if (resultService is not null)
            {
                result = Ok(resultService);
            }
            else
            {
                result = NotFound();
            }
            return Task.FromResult(result);

        }
        // [HttpGet(Name = "SelectAreaByID")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(AreaSelectByIdResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> SelectAreaByID(AreaSelectByIdResponseDto dto)
        // {
        //     var resultService = _site.SelectAreaByID(dto).Result;
        //     IActionResult result;
        //     if (resultService is not null)
        //     {
        //         result = Ok(resultService);
        //     }
        //     else
        //     {
        //         result = NotFound();
        //     }
        //     return Task.FromResult(result);
        //
        // }
        // [HttpGet(Name = "SelectControllerByID")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ControllerSelectByIdRequstDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> SelectControllerByID(ControllerSelectByIdRequstDto dto)
        // {
        //     var resultService = _site.SelectControllerByID(dto).Result;
        //     IActionResult result;
        //     if (resultService is not null)
        //     {
        //         result = Ok(resultService);
        //     }
        //     else
        //     {
        //         result = NotFound();
        //     }
        //     return Task.FromResult(result);
        // }
        // [HttpGet(Name = "SelectActionByID")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ActionSelectByIdRequstDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> SelectActionByID(ActionSelectByIdRequstDto dto)
        // {
        //     var resultService = _site.SelectActionByID(dto).Result;
        //     IActionResult result;
        //     if (resultService is not null)
        //     {
        //         result = Ok(resultService);
        //     }
        //     else
        //     {
        //         result = NotFound();
        //     }
        //     return Task.FromResult(result);
        // }
        // [HttpPost(Name = "CreateSite")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(SiteCreateRequestDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> CreateSite(SiteCreateRequestDto dto)
        // {
        //     var resultService = _site.CreateSite(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        // 
        // [HttpDelete(Name = "DeleteSite")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(SiteDeleteRequestDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> DeleteSite(SiteDeleteRequestDto dto)
        // {
        //     var resultService = _site.DeleteSite(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        // 
        // [HttpPut(Name = "UpdateSite")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(SiteUpdateRequestDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> UpdateSite(SiteUpdateRequestDto dto)
        // {
        //     var resultService = _site.UpdateSite(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        // 
        // [HttpDelete(Name = "DeleteArea")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(AreaDeleteResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> DeleteArea(AreaDeleteRequestDto dto)
        // {
        //     var resultService = _site.DeleteArea(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        //
        //
        // [HttpPut(Name = "UpdateArea")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(AreaUpdateResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> UpdateArea(AreaUpdateRequestDto dto)
        // {
        //     var resultService = _site.UpdateArea(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        //
        // [HttpDelete(Name = "DeleteController")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ControllerDeleteResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> DeleteController(ControllerDeleteRequestDto dto)
        // {
        //     var resultService = _site.DeleteController(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        //
        //
        // [HttpPut(Name = "UpdateController")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ControllerUpdateResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> UpdateController(ControllerUpdateRequestDto dto)
        // {
        //     var resultService = _site.UpdateController(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        //
        // [HttpDelete(Name = "DeleteAction")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ActionDeleteResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> DeleteAction(ActionDeleteRequestDto dto)
        // {
        //     var resultService = _site.DeleteAction(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
        //
        // [HttpPut(Name = "UpdateAction")]
        // [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ActionUpdateResponseDto))]
        // [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        // public Task<IActionResult> UpdateAction(ActionUpdateRequestDto dto)
        // {
        //     var resultService = _site.UpdateAction(dto).Result;
        //     IActionResult result = Ok(resultService);
        //     return Task.FromResult(result);
        // }
    }
}