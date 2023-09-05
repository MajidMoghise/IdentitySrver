using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contract.Models.Action;
using Domain.Contract.Models.Site;
using Domain.Contract.Repositories;
using EFDBContext;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.Action
{
    public class ActionRepository : IActionRepository
    {
        private readonly DbSet<Domain.Action> _actions;
        private readonly ActionMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public ActionRepository(IdentityServerDbContext context)
        {
            _actions = context.Set<Domain.Action>();
            _mapper = new ActionMapper();
            _context=context;
        }
        public Task<ActionCreateResponseModel> Create(ActionCreateRequestModel model)
        {
            var create = _mapper.Action(model);
            var resultdb = _actions.Add(create);
            _context.SaveChanges();
            var result = _mapper.ActionCreateResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<ActionDeleteResponseModel> Delete(ActionDeleteRequestModel model)
        {
            var delete = _mapper.Action(input:model);
            var resultdb = _actions.Remove(delete);
            _context.SaveChanges();
            var result = _mapper.ActionDeleteResponseModel(resultdb);
            return Task.FromResult(result);
        }

        public Task<ActionSelectByIdResponseModel> SelectById(ActionSelectByIdRequestModel model)
        {
            return _actions.Select(_mapper.ActionSelectByIdResponseModel)
                           .SingleOrDefaultAsync(w => w.ActionID == model.ActionID);
        }

        public Task<ActionUpdateResponseModel> Update(ActionUpdateRequestModel model)
        {
            var update = _mapper.Action(model);
            var resultdb = _actions.Update(update);
            _context.SaveChanges();
            var result = _mapper.ActionUpdateResponseModel(resultdb);
            return Task.FromResult(result);

        }
    }
}
