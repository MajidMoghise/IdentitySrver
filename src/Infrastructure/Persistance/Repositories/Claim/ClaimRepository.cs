using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Claim;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Claim
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly DbSet<Domain.Claim> _claims;
        private readonly ClaimMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public ClaimRepository(IdentityServerDbContext context)
        {
            _claims = context.Set<Domain.Claim>();
            _mapper = new ClaimMapper();
            _context=context;
        }
        public Task<ClaimCreateResponseModel> Create(ClaimCreateRequestModel model)
        {
            var create = _mapper.Claim(model);
            var resultdb = _claims.Add(create);
            _context.SaveChanges();
            var result = _mapper.ClaimCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<ClaimDeleteResponseModel> Delete(ClaimDeleteRequestModel model)
        {
            var delete = _mapper.Claim(input:model);
            var resultdb = _claims.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.ClaimDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<PageResponseModel<ClaimSelectByFilterResponseModel>> SelectByFilter(ClaimSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.Claim> predicate = PredicateBuilder.New<Domain.Claim>(true);
            if (!string.IsNullOrEmpty(model.ClaimName?.Trim()))
            {
                _ = predicate.And(p => p.ClaimName.Contains(model.ClaimName));
            }
            if(model.ParentClaimID>0)
            {
                _ = predicate.And(p => p.ParentClaimID == model.ParentClaimID);
            }
            var resultTask = _claims.Where(predicate)
                                  .Select(_mapper.ClaimSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _claims.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_ClaimSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }

        public Task<ClaimSelectByIdResponseModel> SelectByID(ClaimSelectByIdRequestModel model)
        {
            return _claims.Select(_mapper.ClaimSelectByIdResponseModel)
                    .SingleOrDefaultAsync(w => w.ClaimID == model.ClaimID);
        }

        public Task<ClaimUpdateResponseModel> Update(ClaimUpdateRequestModel model)
        {
            var update = _mapper.Claim(model);
            var resultdb = _claims.Update(update);
            _context.SaveChanges();
            var result = _mapper.ClaimUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
