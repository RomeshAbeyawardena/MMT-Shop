using Dapper;

namespace MMTShop.Shared.Contracts
{
    public interface IDatabaseQueryProvider
    {
        CommandDefinition GetCommand(string key, object parameters = null);
    }
}
