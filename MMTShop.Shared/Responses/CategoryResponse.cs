using MMTShop.Shared.Base;
using MMTShop.Shared.Models;
using System.Collections.Generic;

namespace MMTShop.Shared.Responses
{
    public class CategoryResponse : ResponseBase
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
