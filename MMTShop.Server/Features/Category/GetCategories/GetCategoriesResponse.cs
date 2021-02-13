using System.Collections.Generic;

namespace MMTShop.Server.Features.Category.GetCategories
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Shared.Models.Category> Categories { get; internal set; }
    }
}
