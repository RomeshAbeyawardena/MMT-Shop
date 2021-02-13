using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Pipelines.Behaviors
{
    public class ValidateRequestRequestPreProcessor<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validator = validatorFactory.GetValidator<TRequest>();

            if(validator != null)
            {
                await validator
                    .ValidateAndThrowAsync(request, cancellationToken);
            }

            return await next();
        }

        public ValidateRequestRequestPreProcessor(
            IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }
         
        private readonly IValidatorFactory validatorFactory;
    }
}
