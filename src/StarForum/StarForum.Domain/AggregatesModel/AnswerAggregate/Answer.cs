using System;
using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.AnswerAggregate
{
    public class Answer : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
