using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Contract.Models.Base;
using Domain.Contract.Models.Users;
using Domain.Contract.Repositories;
using EFDBContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<Domain.User> _users;
        private readonly DbSet<Domain.Token> _tokens;
        private readonly UserMapper _mapper;
        private readonly IdentityServerDbContext _context;
        public UserRepository(IdentityServerDbContext context)
        {
            _users = context.Set<Domain.User>();
            _mapper = new UserMapper();
            _context=context;
        }

        public Task CreateToken(UserTokenModelRequest model)
        {
            var createDomain = _mapper.Token(model);
            _tokens.AddAsync(createDomain);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task CreateUser(UserCreateRequestModel model)
        {
            var create = _mapper.User(model);
            var resultdb = _users.Add(create);
            _context.SaveChanges();
            var result = _mapper.UserCreateResponseModel(resultdb);
            return Task.CompletedTask;
        }

        public Task<UserLoginModelResponse> CheckUserNamePassword(UserLoginModelRequest userLogin)
        {
            var domain = _mapper.User(userLogin);
            return _users.Where(s => s.UserName == userLogin.UserName && s.Password == userLogin.Password)
                         .Select(_mapper.UserLoginModelResponse)
                         .AsNoTracking()
                         .SingleOrDefaultAsync();
        }

        public Task IsLogin(UserIsLoginResponseModel userLogout)
        {
            var domain = _mapper.User(input: userLogout);
            _context.Entry(domain).Member(nameof(Domain.User.IsLogin)).IsModified=true;
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ResetPassword(UserResetPasswordRequestModel model)
        {
            var domain = _mapper.User(input: model);
            _context.Entry(domain).Member(nameof(Domain.User.Password)).IsModified = true;
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<PageResponseModel<UserSelectByFilterResponseModel>> SelectByFilter(UserSelectByFilterRequestModel model)
        {
            ExpressionStarter<Domain.User> predicate = PredicateBuilder.New<Domain.User>(true);
            if (!string.IsNullOrEmpty(model.UserName?.Trim()))
            {
                _ = predicate.And(p => p.UserName.Contains(model.UserName));
            }
            var resultTask = _users.Where(predicate)
                                  .Select(_mapper.UserSelectByFilterResponseModel)
                                  .Skip((model.PageIndex - 1) * model.NumberInPage)
                                  .Take(model.NumberInPage)
                                  .AsNoTracking()
                                  .ToListAsync().Result;

            var totalCount = _users.Where(predicate).Count();
            double pg = (double)totalCount / model.NumberInPage;
            var pageCount = Convert.ToInt32(Math.Round(pg, MidpointRounding.ToPositiveInfinity));
            var result = _mapper.PageResponseModel_UserSelectByFilterResponseModel(input:resultTask, model.PageIndex, totalCount, pageCount);
            return Task.FromResult(result);

        }

        public Task<UserSelectByIdResponseModel> SelectByID(UserSelectByIdRequestModel model)
        {
            return _users.Select(_mapper.UserSelectByIdResponseModel)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(w => w.UserID == model.UserID);
        }

        public Task<UserTokenValidModelResponse> TokenValid(UserTokenValidModelRequest userTokenValid)
        {
            var domain = _tokens.SingleOrDefaultAsync(s => s.TokenID == userTokenValid.TokenID && s.UserID == userTokenValid.UserID);
            return Task.FromResult(_mapper.UserTokenValidModelResponse(domain.Result));    
        }

        public Task UserIsActive(UserDisableRequestModel model)
        {
            var domain = _mapper.User(input: model);
            _context.Entry(domain).Member(nameof(Domain.User.IsActive)).IsModified = true;
            _context.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
