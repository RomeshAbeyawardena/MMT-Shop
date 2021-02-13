using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Shared.Constants
{
    public static class ServiceConstants
    {
        public static IEnumerable<string> ServerServiceTypes => new [] { "Provider", "Repository", "Factory" };
    }
}
