using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;

namespace MMTShop.Server.Features.Category
{
    public class CategoryRepository 
        : RepositoryBase, ICategoryRepository
    {
        public async Task<IEnumerable<Models.Category>> GetCategoriesAsync(
            CancellationToken cancellationToken)
        {
            return await DbConnection
                .QueryAsync<Models.Category>(DatabaseQueryProvider
                    .GetCommand(DataConstants.GetCategories));
        }

        public CategoryRepository (
            IDbConnection dbConnection,
            IDatabaseQueryProvider databaseQueryProvider)
            : base(dbConnection,
                   databaseQueryProvider)
        {
        }
    }
}
