using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Role;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbSet<Domain.Role> _roles;
        private readonly RoleMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public RoleRepository(IdentityServerDbContext context)
        {
            _roles = context.Set<Domain.Role>();
            _mapper = new RoleMapper();
            _context=context;
        }
        public Task<RoleCreateResponseModel> Create(RoleCreateRequestModel model)
        {
            var create = _mapper.Role(model);
            var resultdb = _roles.Add(create);
            _context.SaveChanges();
            var result = _mapper.RoleCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<RoleDeleteResponseModel> Delete(RoleDeleteRequestModel model)
        {
            var delete = _mapper.Role(input:model);
            var resultdb = _roles.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.RoleDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<PageResponseModel<RoleSelectByFilterResponseModel>> SelectByFilter(RoleSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.Role> predicate = PredicateBuilder.New<Domain.Role>(true);
            if (!string.IsNullOrEmpty(model.RoleName?.Trim()))
            {
                _ = predicate.And(p => p.RoleName.Contains(model.RoleName));
            }
            if(model.ParentRoleID>0)
            {
                _ = predicate.And(p => p.ParentRoleID == model.ParentRoleID);
            }
            var resultTask = _roles.Where(predicate)
                                  .Select(_mapper.RoleSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _roles.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_RoleSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }

        public Task<RoleSelectByIdResponseModel> SelectByID(RoleSelectByIdRequestModel model)
        {
            return _roles.Select(_mapper.RoleSelectByIdResponseModel)
                    .SingleOrDefaultAsync(w => w.RoleID == model.RoleID);
        }

        public Task<RoleUpdateResponseModel> Update(RoleUpdateRequestModel model)
        {
            var update = _mapper.Role(model);
            var resultdb = _roles.Update(update);
            _context.SaveChanges();
            var result = _mapper.RoleUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
