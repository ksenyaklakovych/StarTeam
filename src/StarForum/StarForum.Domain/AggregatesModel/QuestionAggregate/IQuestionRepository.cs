using System.Threading.Tasks;
using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Question Add(Question question);

        void Update(Question question);

        Task<Question> GetAsync(int questionId);
    }
}
