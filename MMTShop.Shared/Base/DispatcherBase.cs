using MMTShop.Shared.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Base
{
    public abstract class DispatcherBase<T> : IDispatcher<T>
    {
        public abstract T Invoke(
            object state);

        public abstract Task<T> InvokeAsync(
            object state, 
            CancellationToken cancellationToken);

        object IDispatcher.Invoke(
            object state)
        {
            return Invoke(state);
        }

        async Task<object> IDispatcher.InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            return await InvokeAsync(state, cancellationToken);
        }
    }
}
