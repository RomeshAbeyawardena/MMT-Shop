using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts
{
    public interface ICommandDispatcher<TCommand>
    {
        IDispatcherHandler GetDispatcherHandler(
            TCommand command);

        IDispatcherHandler<TResult> GetDispatcherHandler<TResult>(
            TCommand command);

        object Invoke(
            TCommand command,
            object state);

        TResult Invoke<TResult>(
            TCommand command,
            object state);

        Task<object> InvokeAsync(
            TCommand command, 
            object state, 
            CancellationToken cancellationToken);

        Task<TResult> InvokeAsync<TResult>(
            TCommand command, 
            object state, 
            CancellationToken cancellationToken);
    }
}
