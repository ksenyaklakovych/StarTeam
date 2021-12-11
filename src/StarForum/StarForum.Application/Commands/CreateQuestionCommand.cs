using System.Runtime.Serialization;
using MediatR;

namespace StarForum.Application.Commands
{
    [DataContract]
    public class CreateQuestionCommand : IRequest<bool>
    {
        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public string Description { get; private set; }

        [DataMember]
        public string CreatedDate { get; private set; }

        [DataMember]
        public string AuthorId { get; private set; }
    }
}
