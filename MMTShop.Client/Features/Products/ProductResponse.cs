using System.Collections.Generic;

namespace MMTShop.Client.Features.Products
{
    public class ProductResponse
    {
        public IEnumerable<Shared.Models.Product> Products { get; set; }
    }
}
