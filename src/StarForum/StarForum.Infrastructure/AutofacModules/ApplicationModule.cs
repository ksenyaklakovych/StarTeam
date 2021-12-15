using System.Reflection;
using Autofac;
using StarForum.Application.Commands;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using StarForum.Domain.AggregatesModel.AnswerAggregate;
using StarForum.Infrastructure.Repositories;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using StarForum.Domain.AggregatesModel.UserAggregate;

namespace StarForum.Domain.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new QuestionQueries(QueriesConnectionString))
            //    .As<IQuestionQueries>()
            //    .InstancePerLifetimeScope();
            builder.RegisterType<QuestionRepository>()
                .As<IQuestionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AnswerRepository>()
                .As<IAnswerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserLoginRepository>()
                .As<IUserLoginRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<RequestManager>()
            //    .As<IRequestManager>()
            //    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateQuestionCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
