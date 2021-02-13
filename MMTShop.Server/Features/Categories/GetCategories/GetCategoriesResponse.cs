using MMTShop.Shared.Models;
using System.Collections.Generic;

namespace MMTShop.Server.Features.Categories.GetCategories
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Category> Categories { get; internal set; }
    }
}
