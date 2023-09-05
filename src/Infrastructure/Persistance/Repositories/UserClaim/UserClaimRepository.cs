using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.UserClaim;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.UserClaim
{
    public class UserClaimRepository : IUserClaimRepository
    {
        private readonly DbSet<Domain.UserClaim> _UserClaims;
        private readonly UserClaimMapper _mapper;
        private readonly IdentityServerDbContext _context;
        private readonly DbSet<Domain.Action> _actions;
        public UserClaimRepository(IdentityServerDbContext context)
        {
            _UserClaims = context.Set<Domain.UserClaim>();
            _actions = context.Set<Domain.Action>();
            _mapper = new UserClaimMapper();
            _context=context;
        }
        public Task Create(UserClaimCreateRequestModel model)
        {
            var create = _mapper.UserClaim(model);
            var resultdb = _UserClaims.Add(create);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(UserClaimDeleteRequestModel model)
        {
            var delete = _mapper.UserClaim(input:model);
            var resultdb = _UserClaims.Remove(delete);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<UserClaimSelectByIdResponseModel> SelectByID(UserClaimSelectByIdRequestModel model)
        {
            ExpressionStarter<Domain.UserClaim> predicate = PredicateBuilder.New<Domain.UserClaim>(true);
            if (model.UserID>0)
            {
                _ = predicate.And(p => p.UserID==model.UserID);
            }
            if (model.ClaimID>0)
            {
                _ = predicate.And(p => p.ClaimID == model.ClaimID);
            }
            var resultTask = _UserClaims
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(s => s.UserID == model.UserID && s.ClaimID == model.ClaimID).Result;
                                  
            var result = _mapper.UserClaimSelectByIdResponseModel(input:resultTask);
            return Task.FromResult(result);

        }
        public Task<PageResponseModel<UserClaimSelectByFilterResponseModel>> SelectByFilter(UserClaimSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.UserClaim> predicate = PredicateBuilder.New<Domain.UserClaim>(true);
            if (model.UserID>0)
            {
                _ = predicate.And(p => p.UserID==model.UserID);
            }
            if (!string.IsNullOrEmpty(model.ClaimName))
            {
                _ = predicate.And(p => p.Claim.ClaimName.Contains(model.ClaimName));
            }
            if (!string.IsNullOrEmpty(model.UserName))
            {
                _ = predicate.And(p => p.User.UserName.Contains(model.UserName));
            }
            if (model.ClaimID>0)
            {
                _ = predicate.And(p => p.ClaimID == model.ClaimID);
            }
            var resultTask = _UserClaims.Where(predicate)
                                  .Select(_mapper.UserClaimSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _UserClaims.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_UserClaimSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }
    }
}
