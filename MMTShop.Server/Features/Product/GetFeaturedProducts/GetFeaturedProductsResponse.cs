using MMTShop.Server.Base;
using System.Collections.Generic;

namespace MMTShop.Server.Features.Product.GetFeaturedProducts
{
    public class GetFeaturedProductsResponse : ResponseBase
    {
        public IEnumerable<Shared.Models.Product> Products { get; internal set; }
    }
}
