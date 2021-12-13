using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Domain.AggregatesModel.UserLoginsAggregate
{
    public class UserLogin : Entity, IAggregateRoot
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
