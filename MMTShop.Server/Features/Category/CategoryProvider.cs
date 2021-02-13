using Dapper;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category
{
    public class CategoryProvider : ICategoryProvider
    {
        public async Task<IEnumerable<Shared.Models.Category>> GetCategories(CancellationToken cancellationToken)
        {
            return await dbConnection
                .QueryAsync<Shared.Models.Category>(dataAccess
                    .GetCommand(DataConstants.GetCategories));

        }

        public CategoryProvider( 
            IDbConnection dbConnection,
            IDataAccess dataAccess)
        {
            this.dbConnection = dbConnection;
            this.dataAccess = dataAccess;
        }

        private readonly IDbConnection dbConnection;
        private readonly IDataAccess dataAccess;
    }
}
