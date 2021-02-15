using MMTShop.Shared.Contracts;
using MMTShop.Shared.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Base
{
    public class CommandDispatcherBase<TCommand> 
        : ICommandDispatcher<TCommand>
    {
        public IDispatcherHandler GetDispatcherHandler(
            TCommand command)
        {
            if(DispatcherDictionary
                .TryGetValue(command, out var dispatcher))
            {
                var handler = serviceProvider
                    .GetService(dispatcher) ;

                return handler as IDispatcherHandler;
            }

            throw new DispatcherNotFoundException(
                "Dispatcher not found for the specified command");
        }

        public IDispatcherHandler<TResult> GetDispatcherHandler<TResult>(
            TCommand command)
        {
            var dispatcher = GetDispatcherHandler(command);

            if(dispatcher is IDispatcherHandler<TResult> genericDispatcher)
            {
                return genericDispatcher;
            }

            throw new InvalidCastException(
                $"Dispatcher does not return a type of {nameof(TResult)}");
        }

        public object Invoke(
            TCommand command,
            object state)
        {
            return GetDispatcherHandler(command)
                .Invoke(state);
        }

        public TResult Invoke<TResult>(
            TCommand command,
            object state)
        {
            return GetDispatcherHandler<TResult>(command)
                .Invoke(state);
        }

        public Task<object> InvokeAsync(
            TCommand command,
            object state,
            CancellationToken cancellationToken)
        {
            return GetDispatcherHandler(command)
                .InvokeAsync(state, cancellationToken);
        }

        public Task<TResult> InvokeAsync<TResult>(
            TCommand command, 
            object state,
            CancellationToken cancellationToken)
        {
            return GetDispatcherHandler<TResult>(command)
                .InvokeAsync(state, cancellationToken);
        }

        protected CommandDispatcherBase(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider =  serviceProvider;
            DispatcherDictionary = new ConcurrentDictionary<TCommand, Type>();
        }

        protected ConcurrentDictionary<TCommand, Type> DispatcherDictionary { get; }

        private readonly IServiceProvider serviceProvider;
    }
}
