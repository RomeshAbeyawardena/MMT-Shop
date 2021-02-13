using MMTShop.Shared.Contracts;
using System.Data;

namespace MMTShop.Server.Base
{
    public class RepositoryBase
    {
        public RepositoryBase (
            IDbConnection dbConnection,
            IDatabaseQueryProvider databaseQueryProvider)
        {
            DbConnection = dbConnection;
            DatabaseQueryProvider = databaseQueryProvider;
        }

        protected IDbConnection DbConnection { get; }
        protected IDatabaseQueryProvider DatabaseQueryProvider { get; }
    }
}
