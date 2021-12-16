using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarForum.Domain.Abstract;
using StarForum.Domain.AggregatesModel.AnswerAggregate;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using StarForum.Infrastructure.Repositories;

namespace StarForum.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StarForumDb");
            services.AddDbContext<StarForumContext>(opts => opts.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}