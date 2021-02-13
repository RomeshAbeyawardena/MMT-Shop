using Dapper;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts;
using System.Collections.Generic;

namespace MMTShop.Shared
{
    public class DataAccess : IDataAccess
    {
        public DataAccess()
        {
            selectQueryCommands = new Dictionary<string, string>
            {
                { DataConstants.GetCategories, "EXEC [dbo].[usp_GetCategories]" },
                { DataConstants.GetFeaturedProducts, "EXEC [dbo].[usp_GetFeaturedProducts]" },
                { DataConstants.GetProductsByCategoryName, "EXEC [dbo].[usp_GetProductsByCategory] @category = @categoryName " }
            };
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
