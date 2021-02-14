using MMTShop.Shared.Contracts;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Base
{
    public class CommandDispatcherManagerBase<TCommand> 
        : ICommandDispatcherManager<TCommand>
    {
        public IDispatcher GetDispatcher(
            TCommand command)
        {
            if(DispatcherDictionary
                .TryGetValue(command, out var dispatcher))
            {
                return serviceProvider
                    .GetService(dispatcher) as IDispatcher;
            }

            throw new NullReferenceException("Dispatcher not found");
        }

        public IDispatcher<TResult> GetDispatcher<TResult>(
            TCommand command)
        {
            var dispatcher = GetDispatcher(command);

            if(dispatcher is IDispatcher<TResult> genericDispatcher)
            {
                return genericDispatcher;
            }

            throw new InvalidOperationException($"Dispatcher does not return a type of {nameof(TResult)}");
        }

        public object InvokeDispatcher(
            TCommand command,
            object state)
        {
            return GetDispatcher(command)
                .Invoke(state);
        }

        public TResult InvokeDispatcher<TResult>(
            TCommand command,
            object state)
        {
            return GetDispatcher<TResult>(command)
                .Invoke(state);
        }

        public Task<object> InvokeDispatcherAsync(
            TCommand command,
            object state,
            CancellationToken cancellationToken)
        {
            return GetDispatcher(command)
                .InvokeAsync(state, cancellationToken);
        }

        public Task<TResult> InvokeDispatcherAsync<TResult>(
            TCommand command, 
            object state,
            CancellationToken cancellationToken)
        {
            return GetDispatcher<TResult>(command)
                .InvokeAsync(state, cancellationToken);
        }

        protected CommandDispatcherManagerBase(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider =  serviceProvider;
            DispatcherDictionary = new ConcurrentDictionary<TCommand, Type>();
        }

        protected ConcurrentDictionary<TCommand, Type> DispatcherDictionary { get; }

        private readonly IServiceProvider serviceProvider;
    }
}
