using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using StarForum.Common.Extensions;
using StarForum.Domain.Exceptions;

namespace StarForum.Application.Behaviours
{
    public class ValidatorBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehaviour(IValidator<TRequest>[] validators) => _validators = validators;

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null)
                .ToList();

            if(failures.Any())
            {
                throw new DomainException(
                    $"Command Validation Errors for type {typeof(TRequest).Name}",
                    new ValidationException("Validation exception", failures));
            }

            return await next();
        }
    }
}