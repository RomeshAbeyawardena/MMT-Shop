using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts
{
    public interface IDispatcher<TResult> : IDispatcher
    {
        new Task<TResult> InvokeAsync(
            object state, 
            CancellationToken cancellationToken);

        new TResult Invoke(
            object state);
    }

    public interface IDispatcher 
    {
        Task<object> InvokeAsync(
            object state, 
            CancellationToken cancellationToken);

        object Invoke(
            object state);
    }
}
