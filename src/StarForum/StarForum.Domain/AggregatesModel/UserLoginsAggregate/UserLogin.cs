using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.UserLoginsAggregate
{
    public class UserLogin : Entity, IAggregateRoot
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderName { get; set; }
    }
}
