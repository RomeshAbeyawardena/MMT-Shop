using MMTShop.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
