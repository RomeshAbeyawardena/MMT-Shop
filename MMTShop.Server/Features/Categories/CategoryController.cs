using Microsoft.AspNetCore.Mvc;
using MMTShop.Server.Base;
using MMTShop.Server.Features.Categories.GetCategories;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Categories
{
    public class CategoryController : MediatrControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetCategories(
            [FromQuery]GetCategoriesRequest request, 
            CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken);
        }
    }
}
