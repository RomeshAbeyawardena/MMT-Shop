using Dapper;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Product
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Shared.Models.Product>> GetFeaturedProductsAsync(
            DateTime? promotionValidFrom, 
            DateTime? promotionValidTo, 
            CancellationToken cancellationToken)
        {
            return await dbConnection
                .QueryAsync<Shared.Models.Product>(databaseQueryProvider
                    .GetCommand(DataConstants.GetFeaturedProducts, new {
                        promotionValidFrom,
                        promotionValidTo
                    }));
        }

        public async Task<IEnumerable<Shared.Models.Product>> GetProductsAsync(
            string categoryName, 
            CancellationToken cancellationToken)
        {
             return await dbConnection
                .QueryAsync<Shared.Models.Product>(databaseQueryProvider
                    .GetCommand(DataConstants.GetProductsByCategoryName, 
                        new { categoryName }));
        }

        public ProductRepository(
            IDbConnection dbConnection,
            IDatabaseQueryProvider databaseQueryProvider)
        {
            this.dbConnection = dbConnection;
            this.databaseQueryProvider = databaseQueryProvider;
        }

        private readonly IDbConnection dbConnection;
        private readonly IDatabaseQueryProvider databaseQueryProvider;
    }
}
