﻿using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;

namespace MMTShop.Server.Features.Product
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public async Task<IEnumerable<Models.Product>> GetFeaturedProductsAsync(
            DateTime? promotionValidFrom, 
            DateTime? promotionValidTo, 
            CancellationToken cancellationToken)
        {
            return await DbConnection
                .QueryAsync<Models.Product>(DatabaseQueryProvider
                    .GetCommand(DataConstants.GetFeaturedProducts, new {
                        promotionValidFrom,
                        promotionValidTo
                    }));
        }

        public async Task<IEnumerable<Models.Product>> GetProductsAsync(
            string categoryName, 
            CancellationToken cancellationToken)
        {
             return await DbConnection
                .QueryAsync<Models.Product>(DatabaseQueryProvider
                    .GetCommand(DataConstants.GetProductsByCategoryName, 
                        new { categoryName }));
        }

        public ProductRepository (
            IDbConnection dbConnection,
            IDatabaseQueryProvider databaseQueryProvider)
            : base(dbConnection,
                   databaseQueryProvider)
        {
            
        }
    }
}
