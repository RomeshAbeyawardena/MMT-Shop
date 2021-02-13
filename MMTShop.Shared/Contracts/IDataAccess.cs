using Dapper;

namespace MMTShop.Shared.Contracts
{
    public interface IDataAccess
    {
        CommandDefinition GetCommand(string key, object parameters = null);
    }
}
