using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Site;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Site
{
    public class SiteRepository : ISiteRepository
    {
        private readonly DbSet<Domain.Site> _sites;
        private readonly SiteMapper _mapper;
        private readonly IdentityServerDbContext _context;
        private readonly DbSet<Domain.Action> _actions;
        public SiteRepository(IdentityServerDbContext context)
        {
            _sites = context.Set<Domain.Site>();
            _actions = context.Set<Domain.Action>();
            _mapper = new SiteMapper();
            _context=context;
        }
        public Task<SiteCreateResponseModel> Create(SiteCreateRequestModel model)
        {
            var create = _mapper.Site(model);
            var resultdb = _sites.Add(create);
            _context.SaveChanges();
            var result = _mapper.SiteCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<SiteDeleteResponseModel> Delete(SiteDeleteRequestModel model)
        {
            var delete = _mapper.Site(input:model);
            var resultdb = _sites.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.SiteDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<PageResponseModel<SiteSelectByFilterResponseModel>> SelectByFilter(SiteSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.Action> predicate = PredicateBuilder.New<Domain.Action>(true);
            if (!string.IsNullOrEmpty(model.SiteName?.Trim()))
            {
                _ = predicate.And(p => p.Controller.Area.Site.SiteName.Contains(model.SiteName));
            }
            var resultTask = _actions.Where(predicate)
                                  .Select(_mapper.SiteSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _actions.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_SiteSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }

        public Task<SiteSelectByIdResponseModel> SelectById(SiteSelectByIdRequestModel model)
        {
            return _sites.Select(_mapper.SiteSelectByIdResponseModel)
                    .SingleOrDefaultAsync(w => w.SiteID == model.SiteID);
        }

        public Task<SiteUpdateResponseModel> Update(SiteUpdateRequestModel model)
        {
            var update = _mapper.Site(model);
            var resultdb = _sites.Update(update);
            _context.SaveChanges();
            var result = _mapper.SiteUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
