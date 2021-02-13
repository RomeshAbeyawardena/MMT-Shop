using System.Collections.Generic;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryResponse
    {
        public IEnumerable<Shared.Models.Product> Products { get; internal set; }
    }
}
