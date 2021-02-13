using System.Collections.Generic;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductResponse
    {
        public IEnumerable<Shared.Models.Product> Products { get; internal set; }
    }
}
