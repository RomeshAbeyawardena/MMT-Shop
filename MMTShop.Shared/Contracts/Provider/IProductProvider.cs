using MMTShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Provider
{
    public interface IProductProvider
    {
        Task<IEnumerable<Product>> GetFeaturedProductsAsync(
            CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetProductsByCategoryName(
            string categoryName, 
            CancellationToken cancellationToken);
    }
}
