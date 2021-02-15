using MMTShop.Shared;
using System;

namespace MMTShop.Client.Base
{
    public abstract class DispatcherHandlerBase<TResult>
        : Shared.Base.DispatcherHandlerBase<bool>
    {
        protected ApplicationState GetApplicationState(object state) 
            => (ApplicationState)state ?? 
                throw new InvalidCastException("Unable to cast state to ApplicationState");

    }
}
