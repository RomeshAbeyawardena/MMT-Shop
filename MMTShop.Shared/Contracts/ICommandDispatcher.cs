using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts
{
    public interface ICommandDispatcher<TCommand>
    {
        IDispatcher GetDispatcher(
            TCommand command);

        IDispatcher<TResult> GetDispatcher<TResult>(
            TCommand command);

        object InvokeDispatcher(
            TCommand command,
            object state);

        TResult InvokeDispatcher<TResult>(
            TCommand command,
            object state);

        Task<object> InvokeDispatcherAsync(
            TCommand command, 
            object state, 
            CancellationToken cancellationToken);

        Task<TResult> InvokeDispatcherAsync<TResult>(
            TCommand command, 
            object state, 
            CancellationToken cancellationToken);
    }
}
