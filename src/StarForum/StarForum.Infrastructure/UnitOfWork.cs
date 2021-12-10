using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StarForum.Domain.Abstract;

namespace StarForum.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly StarForumContext _dbContext;
        private readonly IMediator _mediator;

        public UnitOfWork(StarForumContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            await _mediator.DispatchDomainEventsAsync(_dbContext);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}