using Microsoft.EntityFrameworkCore;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarForum.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StarForumContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public UserRepository(StarForumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddAsync(User user)
        {
            return (await _context.Users.AddAsync(user)).Entity;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context
                                .Users
                                .FirstOrDefaultAsync(o => o.Email == email);
        }
    }
}
