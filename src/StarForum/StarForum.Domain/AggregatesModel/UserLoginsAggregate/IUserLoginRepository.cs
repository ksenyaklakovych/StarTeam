using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarForum.Domain.AggregatesModel.UserLoginsAggregate
{
    public interface IUserLoginRepository : IRepository<UserLogin>
    {
        Task<UserLogin> AddAsync(UserLogin answer);

        Task<User> FindByLoginAsync(string provider, string providerKey);
    }
}
