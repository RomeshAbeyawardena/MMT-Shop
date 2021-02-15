using System;

namespace MMTShop.Shared.Exceptions
{
    [Serializable]
    public class DispatcherNotFoundException : Exception
    {
        public DispatcherNotFoundException() { }
        public DispatcherNotFoundException(string message) : base(message) { }
        public DispatcherNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected DispatcherNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
