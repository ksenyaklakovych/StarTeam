using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;

namespace StarForum.Infrastructure.EntityConfigurations
{
    class UserLoginEntityTypeConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> questionConfiguration)
        {
            questionConfiguration.ToTable("UserLogins");

            questionConfiguration.HasKey(o => o.Id);

            questionConfiguration.Ignore(b => b.DomainEvents);

            questionConfiguration.Property(o => o.Id)
                .UseHiLo("userLoginseq");

            questionConfiguration.Property<string>("LoginProvider");
            questionConfiguration.Property<string>("ProviderKey");
            questionConfiguration.Property<string>("ProviderName");

            questionConfiguration
                .HasOne<User>(s => s.User)
                .WithMany(g => g.UserLogins)
                .HasForeignKey(s => s.UserId);
        }
    }
}
