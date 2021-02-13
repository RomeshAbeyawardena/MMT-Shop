using MMTShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetFeaturedProductsAsync(
            DateTime? promotionValidFrom, 
            DateTime? promotionValidTo, 
            CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetProductsAsync(
            string categoryName,
            CancellationToken cancellationToken);
    }
}
