using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product.GetProductsByCategory
{
    public class GetProductsByCategoryResponse
    {
        public IEnumerable<Shared.Models.Product> Products { get; internal set; }
    }
}
