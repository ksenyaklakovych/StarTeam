using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StarForum.Common.Extensions;
using StarForum.Domain.Abstract;

namespace StarForum.Infrastructure
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, StarForumContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => !x.Entity.DomainEvents.IsNullOrEmpty());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList().ForEach(x => x.Entity.ClearDomainEvents());

            foreach(var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}