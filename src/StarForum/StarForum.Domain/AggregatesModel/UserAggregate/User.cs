using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PasswordHash { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsBlocked { get; set; }
    }
}
