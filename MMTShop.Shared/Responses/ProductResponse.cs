using MMTShop.Shared.Base;
using MMTShop.Shared.Models;
using System.Collections.Generic;

namespace MMTShop.Shared.Responses
{
    public class ProductResponse : ResponseBase
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
