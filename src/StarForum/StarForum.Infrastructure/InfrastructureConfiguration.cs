using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarForum.Domain.Abstract;
using StarForum.Domain.AutofacModules;

namespace StarForum.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<StarForumContext>(opts => opts.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static ContainerBuilder Register(string connectionString, ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new ApplicationModule(connectionString));

            return containerBuilder;
        }
    }
}