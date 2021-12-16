using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

namespace StarForum.Application.Commands
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, bool>
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<bool> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
        {
            var question = new Question() { Title = command.Title, Description = command.Description };

            await _questionRepository.AddAsync(question);

            return await _questionRepository.UnitOfWork
                        .SaveEntitiesAsync(cancellationToken);
        }
    }
}
