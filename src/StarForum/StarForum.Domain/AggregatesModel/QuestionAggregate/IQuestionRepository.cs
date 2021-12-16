using System.Collections.Generic;
using System.Threading.Tasks;
using StarForum.Domain.Abstract;

namespace StarForum.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> AddAsync(Question question);

        void Update(Question question);

        Task<Question> GetAsync(int questionId);

        Task<IEnumerable<QuestionShortModel>> GetAllAsync();
    }
}
