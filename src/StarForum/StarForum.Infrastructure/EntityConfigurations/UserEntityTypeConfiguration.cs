using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> questionConfiguration)
        {
            questionConfiguration.ToTable("Users");

            questionConfiguration.HasKey(o => o.Id);

            questionConfiguration.Ignore(b => b.DomainEvents);

            questionConfiguration.Property(o => o.Id)
                .UseHiLo("userseq");

            questionConfiguration.Property<string>("Name");
            questionConfiguration.Property<string>("Email");
            questionConfiguration.Property<string>("Role");
            questionConfiguration.Property<string>("PasswordHash");
            questionConfiguration.Property<string>("PhotoUrl");
            questionConfiguration.Property<bool>("IsBlocked");
        }
    }
}
