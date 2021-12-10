using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

namespace StarForum.Infrastructure.Repositories
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly StarForumContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public QuestionRepository(StarForumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Question Add(Question question)
        {
            return _context.Questions.Add(question).Entity;

        }

        public async Task<Question> GetAsync(int questionId)
        {
            var question = await _context
                                .Questions
                                .Include(x => x.Title)
                                .FirstOrDefaultAsync(o => o.Id == questionId);
            if (question == null)
            {
                question = _context
                            .Questions
                            .Local
                            .FirstOrDefault(o => o.Id == questionId);
            }

            return question;
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
        }
    }
}
