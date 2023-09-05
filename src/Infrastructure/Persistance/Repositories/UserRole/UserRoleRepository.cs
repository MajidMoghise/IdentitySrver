using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserRole;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.UserRole
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DbSet<Domain.UserRole> _UserRoles;
        private readonly UserRoleMapper _mapper;
        private readonly IdentityServerDbContext _context;
        private readonly DbSet<Domain.Action> _actions;
        public UserRoleRepository(IdentityServerDbContext context)
        {
            _UserRoles = context.Set<Domain.UserRole>();
            _actions = context.Set<Domain.Action>();
            _mapper = new UserRoleMapper();
            _context=context;
        }
        public Task Create(UserRoleCreateRequestModel model)
        {
            var create = _mapper.UserRole(model);
            var resultdb = _UserRoles.Add(create);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(UserRoleDeleteRequestModel model)
        {
            var delete = _mapper.UserRole(input:model);
            var resultdb = _UserRoles.Remove(delete);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<UserRoleSelectByIdResponseModel> SelectByID(UserRoleSelectByIdRequestModel model)
        {
            ExpressionStarter<Domain.UserRole> predicate = PredicateBuilder.New<Domain.UserRole>(true);
            if (model.UserID>0)
            {
                _ = predicate.And(p => p.UserID==model.UserID);
            }
            if (model.RoleID>0)
            {
                _ = predicate.And(p => p.RoleID == model.RoleID);
            }
            var resultTask = _UserRoles
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(s => s.UserID == model.UserID && s.RoleID == model.RoleID).Result;
                                  
            var result = _mapper.UserRoleSelectByIdResponseModel(input:resultTask);
            return Task.FromResult(result);

        }
        public Task<PageResponseModel<UserRoleSelectByFilterResponseModel>> SelectByFilter(UserRoleSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.UserRole> predicate = PredicateBuilder.New<Domain.UserRole>(true);
            if (model.UserID>0)
            {
                _ = predicate.And(p => p.UserID==model.UserID);
            }
            if (!string.IsNullOrEmpty(model.RoleName))
            {
                _ = predicate.And(p => p.Role.RoleName.Contains(model.RoleName));
            }
            if (!string.IsNullOrEmpty(model.UserName))
            {
                _ = predicate.And(p => p.User.UserName.Contains(model.UserName));
            }
            if (model.RoleID>0)
            {
                _ = predicate.And(p => p.RoleID == model.RoleID);
            }
            var resultTask = _UserRoles.Where(predicate)
                                  .Select(_mapper.UserRoleSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _UserRoles.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_UserRoleSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }
    }
}
