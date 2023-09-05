using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Controller;
using Domain.Contract.Models.Site;
using Domain.Contract.Repositories;
using EFDBContext;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Controller
{
    public class ControllerRepository : IControllerRepository
    {
        private readonly DbSet<Domain.Controller> _controllers;
        private readonly ControllerMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public ControllerRepository(IdentityServerDbContext context)
        {
            _controllers = context.Set<Domain.Controller>();
            _mapper = new ControllerMapper();
            _context=context;
        }
        public Task<ControllerCreateResponseModel> Create(ControllerCreateRequestModel model)
        {
            var create = _mapper.Controller(model);
            var resultdb = _controllers.Add(create);
            _context.SaveChanges();
            var result = _mapper.ControllerCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<ControllerDeleteResponseModel> Delete(ControllerDeleteRequestModel model)
        {
            var delete = _mapper.Controller(input:model);
            var resultdb = _controllers.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.ControllerDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<ControllerSelectByIdResponseModel> SelectById(ControllerSelectByIdRequestModel model)
        {
            return _controllers.Select(_mapper.ControllerSelectByIdResponseModel)
                     .SingleOrDefaultAsync(w => w.ControllerID == model.ControllerID);

        }

        public Task<ControllerUpdateResponseModel> Update(ControllerUpdateRequestModel model)
        {
            var update = _mapper.Controller(model);
            var resultdb = _controllers.Update(update);
            _context.SaveChanges();
            var result = _mapper.ControllerUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
