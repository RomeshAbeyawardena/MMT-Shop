using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using MMTShop.Shared.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Pipelines.Behaviors
{
    public class RequestExceptionHandler<TRequest, TResponse, TException> 
        : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception        
    {
        public RequestExceptionHandler(ILogger<TRequest> logger)
        {
            this.logger = logger;
        }

        public Task Handle(
            TRequest request, 
            TException exception, 
            RequestExceptionHandlerState<TResponse> state, 
            CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);

            var response = Activator.CreateInstance<TResponse>();

            if(exception is FluentValidation.ValidationException validationException 
                && response is ResponseBase responseBase)
            { 
                logger.LogError(exception, "Exception handled.");
                responseBase.Errors = validationException.Errors;
                state.SetHandled(response);
            }

            return Task.CompletedTask;
        }

        private readonly ILogger logger;
    }
}
