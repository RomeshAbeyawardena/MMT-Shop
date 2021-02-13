using FluentValidation;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Pipelines.Behaviors
{
    public class ValidateRequestRequestPreProcessor<TRequest> 
        : IRequestPreProcessor<TRequest>
    {
        public async Task Process(
            TRequest request, 
            CancellationToken cancellationToken)
        {
            var validator = validatorFactory.GetValidator<TRequest>();

            if(validator != null)
            {
                await validator.ValidateAndThrowAsync(request, cancellationToken);
            }
        }

        public ValidateRequestRequestPreProcessor(
            IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }
         
        private readonly IValidatorFactory validatorFactory;
    }
}
