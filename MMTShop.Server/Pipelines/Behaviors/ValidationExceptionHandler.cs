using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Pipelines.Behaviors
{
    public class ValidationExceptionHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception
    {
        public Task Handle(
            TRequest request, 
            TException exception, 
            RequestExceptionHandlerState<TResponse> state, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
