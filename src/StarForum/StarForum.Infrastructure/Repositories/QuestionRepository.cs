using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarForum.Application.Models;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.FavouriteAggregate;
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

        public async Task<IEnumerable<QuestionShortModel>> GetAllAsync(FilterModel filter)
        {
            var questionsQuery = _context
                .Questions.Join(_context.Users, q => q.AuthorId,
                    u => u.Id, (q, u) => new QuestionShortModel
                    {
                        Id = q.Id,
                        Title = q.Title,
                        Tags = q.Tags != null ? q.Tags.Split(',', StringSplitOptions.None) : null,
                        Description = q.Description,
                        CreatedDate = q.CreatedDate,
                        AuthorName = u.Name
                    });

            switch (filter.OrderOption)
            {
                case "Date":
                    questionsQuery.OrderByDescending(q => q.CreatedDate);
                    break;
                case "Title":
                    questionsQuery.OrderByDescending(q => q.Title);
                    break;
                default:
                    break;
            }

            var questions = await questionsQuery.ToListAsync();

            return questions;
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
        }

        public async Task<List<Tag>> FilterTagsAsync(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return null;
            }

            var tagsQuery = await _context
                            .Questions.Join(_context.Users, q => q.AuthorId,
                                u => u.Id,
                                (q, u) => q.Tags != null ? q.Tags : "").Select(t => t.Split(',', StringSplitOptions.None).ToList()).ToListAsync();

            List<Tag> tags;

            try
            {
                tags = tagsQuery.SelectMany(l => l).Where(t => t.Contains(filter)).GroupBy(t => t).Select(g => new Tag { Name = g.Key, QuestionCount = g.Count() }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return tags;
        }

        public async Task<IEnumerable<QuestionShortModel>> GetByTagAsync(string tag)
        {
            var questionsQuery = _context
              .Questions.Join(_context.Users, q => q.AuthorId,
                  u => u.Id, (q, u) => new QuestionShortModel
                  {
                      Id = q.Id,
                      Title = q.Title,
                      Tags = q.Tags != null ? q.Tags.Split(',', StringSplitOptions.None) : new string[] { },
                      Description = q.Description,
                      CreatedDate = q.CreatedDate,
                      AuthorName = u.Name
                  });

            var questions = await questionsQuery.ToListAsync();
            var result = questions.Where(q => q.Tags.Count() >= 1 && q.Tags.Contains(tag));

            return result;
        }

        public async Task<bool> CheckFavourite(int questionId)
        {
            var result = await _context.Favourites.FirstOrDefaultAsync(f => f.QuestionId == questionId && f.UserId == 1);
            
            return result != null;
        }

        public async Task<bool> UpdateFavourite(int questionId, bool addToFavourites)
        {
            if (addToFavourites)
            {
                Favourite favourite = new Favourite() { QuestionId = questionId, UserId = 1 };
                await _context.Favourites.AddAsync(favourite);
            }
            else
            {
                Favourite favourite = await _context.Favourites.FirstOrDefaultAsync(f => f.UserId == 1 && f.QuestionId == questionId);
                _context.Favourites.Remove(favourite);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
