using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Infrastructure.EntityConfigurations
{
    class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> questionConfiguration)
        {
            questionConfiguration.ToTable("Questions");

            questionConfiguration.HasKey(o => o.Id);

            questionConfiguration.Ignore(b => b.DomainEvents);

            questionConfiguration.Property(o => o.Id)
                .UseHiLo("questionseq");

            questionConfiguration.HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            questionConfiguration.Property<string>("Description").IsRequired(false);
            questionConfiguration.Property<string>("Title");
        }
    }
}
