using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Products
{
    public class ProductResponse
    {
        public IEnumerable<Shared.Models.Product> Products { get; set; }
    }
}
