using System.Collections.Generic;
using System.Threading.Tasks;
using StarForum.Domain.Abstract;
using StarForum.Application.Models;

namespace StarForum.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> AddAsync(Question question);

        void Update(Question question);

        Task<Question> GetAsync(int questionId);

        Task<IEnumerable<QuestionShortModel>> GetByTagAsync(string tag);

        Task<IEnumerable<QuestionShortModel>> GetAllAsync(FilterModel filter);

        Task<IEnumerable<QuestionShortModel>> GetFavouritesAsync(int userId);
        
        Task<List<Tag>> FilterTagsAsync(string filter);

        Task<bool> CheckFavourite(int questionId);

        Task<bool> UpdateFavourite(int questionId, bool favourite);
    }
}
