using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserRoleClaimAction;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.UserRoleClaimAction
{
    public class UserRoleClaimActionRepository : IUserRoleClaimActionRepository
    {
        private readonly DbSet<Domain.UserRoleClaimAction> _UserRoleClaimActions;
        private readonly UserRoleClaimActionMapper _mapper;
        private readonly IdentityServerDbContext _context;
        private readonly DbSet<Domain.Action> _actions;
        public UserRoleClaimActionRepository(IdentityServerDbContext context)
        {
            _UserRoleClaimActions = context.Set<Domain.UserRoleClaimAction>();
            _actions = context.Set<Domain.Action>();
            _mapper = new UserRoleClaimActionMapper();
            _context=context;
        }
        public Task Create(UserRoleClaimActionCreateRequestModel model)
        {
            var create = _mapper.UserRoleClaimAction(model);
            var resultdb = _UserRoleClaimActions.Add(create);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(UserRoleClaimActionDeleteRequestModel model)
        {
            var delete = _mapper.UserRoleClaimAction(input:model);
            var resultdb = _UserRoleClaimActions.Remove(delete);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<PageResponseModel<UserRoleClaimActionSelectResponseModel>> Select(UserRoleClaimActionSelectRequestModel model)
        {
            ExpressionStarter<Domain.UserRoleClaimAction> predicate = PredicateBuilder.New<Domain.UserRoleClaimAction>(true);
            if (model.UserID>0)
            {
                _ = predicate.And(p => p.UserID==model.UserID);
            }
            if (model.ClaimID>0)
            {
                _ = predicate.And(p => p.ClaimID == model.ClaimID);
            }
            if (model.ActionID>0)
            {
                _ = predicate.And(p => p.ActionID == model.ActionID);
            }
            if (model.RoleID>0)
            {
                _ = predicate.And(p => p.RoleID == model.RoleID);
            }
            var resultTask = _UserRoleClaimActions.Where(predicate)
                                  .Select(_mapper.UserRoleClaimActionSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _UserRoleClaimActions.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_UserRoleClaimActionSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }

        public Task<bool> UserAccess(UserRoleClaimActionSelectRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
