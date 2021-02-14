using MMTShop.Shared.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Base
{
    public abstract class DispatcherHandlerBase<T> : IDispatcherHandler<T>
    {
        public abstract T Invoke(
            object state);

        public abstract Task<T> InvokeAsync(
            object state, 
            CancellationToken cancellationToken);

        object IDispatcherHandler.Invoke(
            object state)
        {
            return Invoke(state);
        }

        async Task<object> IDispatcherHandler.InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            return await InvokeAsync(state, cancellationToken);
        }
    }
}
