using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Area;
using Domain.Contract.Models.Site;
using Domain.Contract.Repositories;
using EFDBContext;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Area
{
    public class AreaRepository : IAreaRepository
    {
        private readonly DbSet<Domain.Area> _areas;
        private readonly AreaMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public AreaRepository(IdentityServerDbContext context)
        {
            _areas = context.Set<Domain.Area>();
            _mapper = new AreaMapper();
            _context=context;
        }
        public Task<AreaCreateResponseModel> Create(AreaCreateRequestModel model)
        {
            var create = _mapper.Area(model);
            var resultdb = _areas.Add(create);
            _context.SaveChanges();
            var result = _mapper.AreaCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<AreaDeleteResponseModel> Delete(AreaDeleteRequestModel model)
        {
            var delete = _mapper.Area(input:model);
            var resultdb = _areas.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.AreaDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<AreaSelectByIdResponseModel> SelectById(AreaSelectByIdRequestModel model)
        {
            return _areas.Select(_mapper.AreaSelectByIdResponseModel)
                          .SingleOrDefaultAsync(w => w.AreaID == model.AreaID);
        }

        public Task<AreaUpdateResponseModel> Update(AreaUpdateRequestModel model)
        {
            var update = _mapper.Area(model);
            var resultdb = _areas.Update(update);
            _context.SaveChanges();
            var result = _mapper.AreaUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
