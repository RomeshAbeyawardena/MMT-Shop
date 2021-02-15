using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
