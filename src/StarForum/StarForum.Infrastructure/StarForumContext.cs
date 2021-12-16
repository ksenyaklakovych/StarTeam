using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.AnswerAggregate;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using StarForum.Infrastructure.EntityConfigurations;

namespace StarForum.Infrastructure
{
    public class StarForumContext: DbContext, IUnitOfWork
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        public StarForumContext(DbContextOptions<StarForumContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuestionEntityTypeConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarForumContext).Assembly);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}