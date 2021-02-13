using Microsoft.AspNetCore.Mvc;
using MMTShop.Server.Base;
using MMTShop.Server.Features.Product.GetFeaturedProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product
{
    public class ProductController : MediatrControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetFeaturedProducts(
            [FromQuery]GetFeaturedProductRequest request, 
            CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }
    }
}
