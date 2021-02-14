using Microsoft.AspNetCore.Mvc;
using MMTShop.Server.Base;
using MMTShop.Server.Features.Category.GetCategories;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category
{
    public class CategoryController 
        : MediatrControllerBase
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
