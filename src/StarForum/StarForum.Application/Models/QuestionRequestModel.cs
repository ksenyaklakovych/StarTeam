using System.Collections.Generic;

namespace StarForum.Application.Models
{
    public class QuestionRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
    }
}
