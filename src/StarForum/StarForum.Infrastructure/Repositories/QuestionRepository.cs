using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarForum.Application.Models;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

namespace StarForum.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
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

        public async Task<Question> AddAsync(Question question)
        {
            var response = await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return response.Entity;
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

        public async Task<IEnumerable<QuestionShortModel>> GetAllAsync()
        {
            var questions = await _context
                .Questions.Join(_context.Users, q => q.AuthorId,
                    u => u.Id, (q, u) => new QuestionShortModel
                    {
                        Title = q.Title,
                        Tags = q.Tags != null ? q.Tags.Split(',', StringSplitOptions.None) : null,
                        Description = q.Description,
                        CreatedDate = q.CreatedDate,
                        AuthorName = u.Name
                    }).OrderByDescending(q => q.CreatedDate).ToListAsync();

            return questions;
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
        }
    }
}
