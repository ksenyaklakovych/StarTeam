using System;
using System.Collections.Generic;
using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.QuestionAggregate
{
    public class Question : Entity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class QuestionShortModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
