using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.AnswerAggregate;

namespace StarForum.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly StarForumContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public AnswerRepository(StarForumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Answer Add(Answer answer)
        {
            return _context.Answers.Add(answer).Entity;
        }

        public async Task<Answer> GetAsync(int answerId)
        {
            var answer = await _context
                                .Answers
                                .Include(x => x.Title)
                                .FirstOrDefaultAsync(o => o.Id == answerId);
            if (answer == null)
            {
                answer = _context
                            .Answers
                            .Local
                            .FirstOrDefault(o => o.Id == answerId);
            }

            return answer;
        }

        public void Update(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
        }
    }
}
