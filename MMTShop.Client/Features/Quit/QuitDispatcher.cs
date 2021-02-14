using MMTShop.Shared.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Quit
{
    public class QuitDispatcher
        : DispatcherBase<bool>
    {
        public override bool Invoke(object state)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> InvokeAsync(object state, CancellationToken cancellationToken)
        {
            if(state is ApplicationState applicationState)
            {
                applicationState.IsRunning = false;
            }

            return Task.FromResult(false);
        }
    }
}
