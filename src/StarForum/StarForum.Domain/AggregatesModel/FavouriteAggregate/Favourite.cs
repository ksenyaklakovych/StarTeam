using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.FavouriteAggregate
{
    public class Favourite : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
