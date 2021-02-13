using MMTShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Categories.GetCategories
{
    public class GetCategoriesResponse
    {
        public IEnumerable<Category> Categories { get; internal set; }
    }
}
