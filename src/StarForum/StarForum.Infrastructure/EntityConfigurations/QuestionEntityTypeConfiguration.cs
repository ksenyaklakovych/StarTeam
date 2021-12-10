using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

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

            questionConfiguration
                .Property<int?>("_authorId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AuthorId")
                .IsRequired(false);

            questionConfiguration
                .Property<DateTime>("_createdDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreatedDate")
                .IsRequired();

            questionConfiguration.Property<string>("Description").IsRequired(false);
            questionConfiguration.Property<string>("Title");
        }
    }
}
