using System.Collections.Generic;

namespace MMTShop.Client.Features.Categories
{
    public class CategoryResponse
    {
        public IEnumerable<Shared.Models.Category> Categories { get; internal set; }
    }
}
