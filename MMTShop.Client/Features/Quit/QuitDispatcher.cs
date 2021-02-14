using MMTShop.Shared.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Quit
{
    /*  
     *  It made sense to have a quit dispatcher for further 
     *  implementation, in case any clean-up tasks are required
     *  before the app quits, such as saving to disk/database. 
     *  It gets given access to the application state  
     *  via the state parameter in Invoke and InvokeAsync
     *  to break out of the while block and allow the application
     *  to terminate gracefully.
    */
    public class QuitDispatcher
        : DispatcherBase<bool>
    {
        public override bool Invoke(object state)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            if(state is ApplicationState applicationState)
            {
                applicationState.IsRunning = false;
            }

            return Task.FromResult(false);
        }
    }
}
