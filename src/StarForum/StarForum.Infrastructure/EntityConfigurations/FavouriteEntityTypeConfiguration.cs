using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.FavouriteAggregate;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Infrastructure.EntityConfigurations
{
    class FavouriteEntityTypeConfiguration : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> questionConfiguration)
        {
            questionConfiguration.ToTable("Favourites");

            questionConfiguration.HasKey(o => o.Id);

            questionConfiguration.Ignore(b => b.DomainEvents);

            //questionConfiguration.Property(o => o.Id)
            //    .UseHiLo("questionseq");

            questionConfiguration.HasOne<Question>()
                .WithMany()
                .HasForeignKey(u => u.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            questionConfiguration.HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
