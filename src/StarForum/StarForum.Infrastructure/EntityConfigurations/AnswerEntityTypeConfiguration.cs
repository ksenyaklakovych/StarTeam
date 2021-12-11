using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.AnswerAggregate;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Infrastructure.EntityConfigurations
{
    class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> questionConfiguration)
        {
            questionConfiguration.ToTable("Answers");

            questionConfiguration.HasKey(o => o.Id);

            questionConfiguration.Ignore(b => b.DomainEvents);

            questionConfiguration.Property(o => o.Id)
                .UseHiLo("answerseq");

            questionConfiguration.HasOne<Question>()
                .WithMany()
                .HasForeignKey(u => u.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            questionConfiguration.HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            questionConfiguration.Property<string>("Description");
            questionConfiguration.Property<string>("Title");
        }
    }
}
