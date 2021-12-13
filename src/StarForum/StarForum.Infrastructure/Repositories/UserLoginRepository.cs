using Microsoft.EntityFrameworkCore;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarForum.Infrastructure.Repositories
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly StarForumContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserLoginRepository(StarForumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UserLogin> AddAsync(UserLogin userLogin)
        {
            return (await _context.UserLogins.AddAsync(userLogin)).Entity;
        }

        public async Task<User> FindByLoginAsync(string provider, string providerKey)
        {
            return (await _context
                                .UserLogins
                                .FirstOrDefaultAsync(o => o.LoginProvider == provider && o.ProviderKey == providerKey))
                                .User;
        }
    }
}
