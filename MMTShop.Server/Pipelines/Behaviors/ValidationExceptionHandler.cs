using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Pipelines.Behaviors
{
    public class ValidationExceptionHandler<TRequest, TResponse, TException>
        : RequestExceptionHandler<TRequest, TResponse, TException>
        where TRequest : IRequest<TResponse>
        where TException : Exception
    {
        protected override void Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state)
        {
            throw new NotImplementedException();
        }
    }
}
