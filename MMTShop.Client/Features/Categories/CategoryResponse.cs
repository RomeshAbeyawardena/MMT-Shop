using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Categories
{
    public class CategoryResponse
    {
        public IEnumerable<Shared.Models.Category> Categories { get; internal set; }
    }
}
