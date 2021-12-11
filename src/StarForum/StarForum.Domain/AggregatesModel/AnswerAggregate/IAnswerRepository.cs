using System.Threading.Tasks;
using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.AnswerAggregate
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Answer Add(Answer answer);

        void Update(Answer answer);

        Task<Answer> GetAsync(int answerId);
    }
}
