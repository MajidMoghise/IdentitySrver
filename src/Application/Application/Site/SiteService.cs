using Application.Contract.Applications;
using Application.Contract.DTOs.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contract.Repositories;
using Domain.Contract.Models.Controller;
using Application.Contract.Dtos.Base;

namespace Application.Site
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAreaRepository _areaRepository;
        private readonly IControllerRepository _controllerRepository;
        private readonly IActionRepository _actionRepository;
        private readonly SiteMapper _mapper;
        public SiteService
                (IUnitOfWork unitOfWork,
                 IAreaRepository areaRepository,
                 IControllerRepository controllerRepository,
                 IActionRepository actionRepository)
        {
            _unitOfWork = unitOfWork;
            _areaRepository = areaRepository;
            _controllerRepository = controllerRepository;
            _actionRepository = actionRepository;
            _mapper = new SiteMapper();
        }
        public Task<SiteCreateResponseDto> CreateSite(SiteCreateRequestDto dto)
        {
            var resultAreas = new List<SiteAreaCreateResponseDto>();
            var resultControllers = new List<SiteAreaControllerCreateResponseDto>();
            var resultActions = new List<SiteAreaControllerActionCreateResponseDto>();
            
                _unitOfWork.BeginTransaction();
                var siteModel = _mapper.SiteCreateRequestModel(dto);
                var resultSiteCreate = _siteRepository.Create(siteModel).Result;
                dto.Areas.ForEach(areaDto =>
                {
                    var areaModel = _mapper.AreaCreateRequestModel(areaDto, resultSiteCreate.SiteID);
                    var resultAreaCreate = _areaRepository.Create(areaModel).Result;
                    areaDto.Controllers.ForEach(controllerDto =>
                    {
                        var controllerModel = _mapper.ControllerCreateRequestModel(controllerDto, resultAreaCreate.AreaID);
                        var resultControllerCreate = _controllerRepository.Create(controllerModel).Result;
                        controllerDto.Actions.ForEach(actionDto =>
                        {
                            var actionModel = _mapper.ActionCreateRequestModel(actionDto, resultControllerCreate.ControllerID);
                            var resultActionCreate = _actionRepository.Create(actionModel).Result;
                            var resultAction = _mapper.SiteAreaControllerActionCreateResponseDto(resultActionCreate);
                            resultActions.Add(resultAction);

                        });
                        var resultController = _mapper.SiteAreaControllerCreateResponseDto(resultControllerCreate, resultActions);
                        resultControllers.Add(resultController);
                    });
                    var resultArea = _mapper.SiteAreaCreateResponseDto(resultAreaCreate, resultControllers);
                    resultAreas.Add(resultArea);
                });
                var result = _mapper.SiteCreateResponseDto(resultSiteCreate, resultAreas);
                _unitOfWork.Commit();

            return Task.FromResult(result);
        }

        public Task<ActionDeleteResponseDto> DeleteAction(ActionDeleteRequestDto dto)
        {
            var deleteModel = _mapper.ActionDeleteRequestModel(dto);
           var resultDelete= _actionRepository.Delete(deleteModel).Result;
            return Task.FromResult(_mapper.ActionDeleteResponseDto(resultDelete));
        }

        public Task<AreaDeleteResponseDto> DeleteArea(AreaDeleteRequestDto dto)
        {
            var deleteModel = _mapper.AreaDeleteRequestModel(dto);
            var resultDelete = _areaRepository.Delete(deleteModel).Result;
            return Task.FromResult(_mapper.AreaDeleteResponseDto(resultDelete));
        }

        public Task<ControllerDeleteResponseDto> DeleteController(ControllerDeleteRequestDto dto)
        {
            var deleteModel = _mapper.ControllerDeleteRequestModel(dto);
            var resultDelete = _controllerRepository.Delete(deleteModel).Result;
            return Task.FromResult(_mapper.ControllerDeleteResponseDto(resultDelete));
        }

        public Task<SiteDeleteResponseDto> DeleteSite(SiteDeleteRequestDto dto)
        {
            var deleteModel = _mapper.SiteDeleteRequestModel(dto);
            var resultDelete = _siteRepository.Delete(deleteModel).Result;
            return Task.FromResult(_mapper.SiteDeleteResponseDto(resultDelete));
        }

        public Task<ActionSelectByIdResponseDto> SelectActionByID(ActionSelectByIdRequstDto dto)
        {
            var SelectByIdModel = _mapper.ActionSelectByIdRequestModel(dto);
            var resultSelectById = _actionRepository.SelectById(SelectByIdModel).Result;
            return Task.FromResult(_mapper.ActionSelectByIdResponseDto(resultSelectById));
        }

        public Task<AreaSelectByIdResponseDto> SelectAreaByID(AreaSelectByIdResponseDto dto)
        {
            var SelectByIdModel = _mapper.AreaSelectByIdRequestModel(dto);
            var resultSelectById = _areaRepository.SelectById(SelectByIdModel).Result;
            return Task.FromResult(_mapper.AreaSelectByIdResponseDto(resultSelectById));
        }

        public Task<ControllerSelectByIdResponseDto> SelectControllerByID(ControllerSelectByIdRequstDto dto)
        {
            var SelectByIdModel = _mapper.ControllerSelectByIdRequestModel(dto);
            var resultSelectById = _controllerRepository.SelectById(SelectByIdModel).Result;
            return Task.FromResult(_mapper.ControllerSelectByIdResponseDto(resultSelectById));
        }

        public Task<PageResponseDto<SiteSelectByFilterResponseDto>> SelectSiteByFilter(SiteSelectByFilterRequestDto dto)
        {
            var SelectByFilterModel = _mapper.SiteSelectByFilterRequestModel(dto);
            var resultSelectByFilter = _siteRepository.SelectByFilter(SelectByFilterModel).Result;
            return Task.FromResult(_mapper.PageResponseDto_SiteSelectByFilterResponseDto(resultSelectByFilter));
        }

        public Task<SiteSelectByIdResponseDto> SelectSiteByID(SiteSelectByIdRequestDto dto)
        {
            var SelectByIdModel = _mapper.SiteSelectByIdRequestModel(dto);
            var resultSelectById = _siteRepository.SelectById(SelectByIdModel).Result;
            return Task.FromResult(_mapper.SiteSelectByIdResponseDto(resultSelectById));
        }

        
        public Task<ActionUpdateResponseDto> UpdateAction(ActionUpdateRequestDto dto)
        {
            var UpdateModel = _mapper.ActionUpdateRequestModel(dto);
            var resultUpdate = _actionRepository.Update(UpdateModel).Result;
            return Task.FromResult(_mapper.ActionUpdateResponseDto(resultUpdate));
        }

        public Task<AreaUpdateResponseDto> UpdateArea(AreaUpdateRequestDto dto)
        {
            var UpdateModel = _mapper.AreaUpdateRequestModel(dto);
            var resultUpdate = _areaRepository.Update(UpdateModel).Result;
            return Task.FromResult(_mapper.AreaUpdateResponseDto(resultUpdate));
        }

        public Task<ControllerUpdateResponseDto> UpdateController(ControllerUpdateRequestDto dto)
        {
            var UpdateModel = _mapper.ControllerUpdateRequestModel(dto);
            var resultUpdate = _controllerRepository.Update(UpdateModel).Result;
            return Task.FromResult(_mapper.ControllerUpdateResponseDto(resultUpdate));
        }

        public Task<SiteUpdateResponseDto> UpdateSite(SiteUpdateRequestDto dto)
        {
            var UpdateModel = _mapper.SiteUpdateRequestModel(dto);
            var resultUpdate = _siteRepository.Update(UpdateModel).Result;
            return Task.FromResult(_mapper.SiteUpdateResponseDto(resultUpdate));
        }
    }
}
