using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using System.Collections.Generic;

namespace StarForum.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public User()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
    }
}
