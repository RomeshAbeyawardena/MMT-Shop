using Dapper;
using MMTShop.Server.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public async Task<IEnumerable<Shared.Models.Category>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            return await dbConnection
                .QueryAsync<Shared.Models.Category>(databaseQueryProvider
                    .GetCommand(DataConstants.GetCategories));
        }

        public CategoryRepository(
            IDbConnection dbConnection,
            IDatabaseQueryProvider databaseQueryProvider)
            : base(dbConnection,
                   databaseQueryProvider)
        {
            this.dbConnection = dbConnection;
            this.databaseQueryProvider = databaseQueryProvider;
        }

        private readonly IDbConnection dbConnection;
        private readonly IDatabaseQueryProvider databaseQueryProvider;
    }
}
