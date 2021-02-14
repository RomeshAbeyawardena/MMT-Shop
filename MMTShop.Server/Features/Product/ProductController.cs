using Microsoft.AspNetCore.Mvc;
using MMTShop.Server.Base;
using MMTShop.Server.Features.Product.GetFeaturedProducts;
using MMTShop.Server.Features.Product.GetProductsByCategory;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product
{
    public class ProductController 
        : MediatrControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetFeaturedProducts(
            [FromQuery]GetFeaturedProductsRequest request, 
            CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }

        [HttpGet, Route("{category}")]
        public Task<IActionResult> GetProductsByCategory(
            [FromRoute]GetProductsByCategoryRequest request, 
            CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }
    }
}
