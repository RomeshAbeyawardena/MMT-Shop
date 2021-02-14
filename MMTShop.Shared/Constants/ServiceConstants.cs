using System.Collections.Generic;

namespace MMTShop.Shared.Constants
{
    public static class ServiceConstants
    {
        public static IEnumerable<string> ServerServiceTypes => new [] { "Provider", "Repository", "Factory" };
        public static IEnumerable<string> ClientServiceTypes => new [] { "Provider", "Module" };
    }
}
