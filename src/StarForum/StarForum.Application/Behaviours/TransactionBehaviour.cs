using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace StarForum.Application.Behaviours
{
    public class TransactionBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    {
        public TransactionBehaviour()
        {
            
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) => null;
    }
}