using MMTShop.Server.Base;
using System.Collections.Generic;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryResponse : ResponseBase
    {
        public IEnumerable<Shared.Models.Product> Products { get; internal set; }
    }
}
