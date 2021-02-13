using Dapper;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Shared
{
    public class DataAccess : IDataAccess
    {
        public DataAccess()
        {
            selectQueryCommands
                .Add(DataConstants.GetFeaturedProducts, "EXEC [dbo].[usp_GetFeaturedProducts]");
            
            selectQueryCommands
                .Add(DataConstants.GetCategories, "EXEC [dbo].[Usp_GetCategories]");
        }

        
        public CommandDefinition GetCommand(string key, object parameters)
        {
            if(selectQueryCommands.TryGetValue(key, out var query))
            {
                return new CommandDefinition(query, parameters);
            }

            throw new KeyNotFoundException();
        }

        private readonly IDictionary<string, string> selectQueryCommands;

    }
}
